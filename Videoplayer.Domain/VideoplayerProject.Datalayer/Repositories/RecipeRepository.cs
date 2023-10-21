using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Datalayer.Exceptions;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Datalayer.Repositories
{
    public class RecipeRepository : IRecipeRepository {

        private string connectionString;

        public RecipeRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public List<Recipe> GetAllRecipes(string filter) {
            try {
                List<Recipe> recipes = new List<Recipe>();
                string sql = "";

                if (string.IsNullOrWhiteSpace(filter)) {
                    sql = "SELECT * FROM Recipes;";
                } else {
                    sql = $"SELECT * FROM Recipes where RecipeName LIKE \"%{filter}%\"";
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = sql;

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                // First initialize a new recipe and add nessecairy properties
                                Recipe recipe = new Recipe((string)reader["RecipeName"],
                                                           (int)reader["Servings"],
                                                           (string)reader["VideoLink"],
                                                           (TimeSpan)reader["CookingTime"]
                                                           );
                                
                                // Get the recipeId to join tables
                                int recipeId = (int)reader["RecipeID"];

                                // Then add all the ingredients with timestamps...
                                string joinCmd = "SELECT BeginTime, EndTime, IngredientID, IngredientName, Price, Brand FROM Recipes" +
                                                 "JOIN RecipeIngredient on Recipes.RecipeID = RecipeIngredient.RecipeID" + 
                                                 "JOIN Ingredients on RecipeIngredient.IngredientID = Ingredients.IngredientID" +
                                                 $"WHERE Recipes.RecipeID = {recipeId};";

                                SqlCommand command = conn.CreateCommand();
                                command.CommandText = joinCmd;

                                using(SqlDataReader dataReader = command.ExecuteReader()) {
                                    if(dataReader.HasRows) {
                                        while(reader.Read()) {
                                            recipe.AddIngredientWithTimeStampToRecipe(new Ingredient(
                                                                                           (int)dataReader["IngredientID"],
                                                                                           (string)dataReader["IngredientName"],
                                                                                           (decimal)dataReader["Price"],
                                                                                           (string)dataReader["Brand"]),

                                                                                      new Timestamp(                        
                                                                                           (TimeSpan)dataReader["BeginTime"],
                                                                                           (TimeSpan)dataReader["EndTime"]));
                                        }
                                    }
                                }


                                // ...and the utensils with timestamps
                                joinCmd = "SELECT BeginTime, EndTime, UtensilName FROM Recipes" +
                                          "JOIN RecipeUtensils ON Recipes.RecipeID = RecipeUtensils.RecipeID" +
                                          "JOIN Utensils ON RecipeUtensils.UtensilID = Utensils.UtensilID" +
                                          $"WHERE Recipes.RecipeID = {recipeId}";
                                command.CommandText = joinCmd;

                                using (SqlDataReader dataReader = command.ExecuteReader()) {
                                    if (dataReader.HasRows) {
                                        while (reader.Read()) {
                                            recipe.AddUtensilWithTimeStampToRecipe(new Utensil(
                                                                                        (int)dataReader["UtensilID"],
                                                                                        (string)dataReader["UtensilName"]),

                                                                                    new Timestamp(
                                                                                           (TimeSpan)dataReader["BeginTime"],
                                                                                           (TimeSpan)dataReader["EndTime"]));
                                        }
                                    }
                                }

                                // Finally, add the recipe to the list
                                recipes.Add(recipe);
                            }
                        }
                    }                  
                }
                return recipes;

            } catch (Exception ex) {

                throw new RecipeRepositoryException("Geef Alle recepten error");
            }
        }

        public void DeleteRecipe(Recipe recipe) {
            try {
                string sql = $"DELETE FROM recipe WHERE (RecipeName = {recipe.Id});";

                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = conn.CreateCommand()) {
                        conn.Open();
                        cmd.CommandText = sql;

                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows < 0) {
                            throw new RecipeRepositoryException("No recipe found to delete.");
                        }
                    }
                }

            } catch (Exception ex) {
                throw;
            }
        }

        public void AddRecipe(Recipe recipe) {
            try {
                string sql = $"INSERT INTO recipe (RecipeName, Servings, VideoLink, CookingTime) " +
                             $"OUTPUT Inserted.id" +
                             $"VALUES (@RecipeName, @Servings, @VideoLink, @CookingTime);";

                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = conn.CreateCommand()) {
                        conn.Open();

                        SqlTransaction transaction = conn.BeginTransaction();

                        try {
                            // Fist: save the recipe object and get the RecipeId via ExecuteScalar
                            cmd.Parameters.AddWithValue("@RecipeName", recipe.Name);
                            cmd.Parameters.AddWithValue("@Servings", recipe.Servings);
                            cmd.Parameters.AddWithValue("@VideoLink", recipe.VideoLink);
                            cmd.Parameters.AddWithValue("@CookingTime", recipe.CookingTime);

                            int recipeId = (int)cmd.ExecuteScalar();

                            // Second: Save the corresponding List of Ingredients and their corresponding timestamps
                            for(int i = 0; i < recipe.IngredientToTimestamp.Count; i++) {
                                cmd.CommandText = "INSERT INTO RecipeIngredient(RecipeID, IngredientD, BeginTime, EndTime) " +
                                                  "VALUES (@RecipeID, @IngredientID, @BeginTime, @EndTime";

                                // Second loop that executes the insert as many times as the ingredient was used in the recipe 
                                // I.e. Insert the same ingredient with different timestamps if it was used more than once
                                for (int j = 0; j < recipe.IngredientToTimestamp.ElementAt(i).Value.Count; j++) {
                                    cmd.Parameters.AddWithValue("@RecipeID", recipeId);
                                    cmd.Parameters.AddWithValue("@IngredientID", recipe.IngredientToTimestamp.ElementAt(i).Key.Id);
                                    cmd.Parameters.AddWithValue("@BeginTime", recipe.IngredientToTimestamp.ElementAt(i).Value[j].StartTime);
                                    cmd.Parameters.AddWithValue("@EndTime", recipe.IngredientToTimestamp.ElementAt(i).Value[j].EndTime);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Third: Save the corresponding list of utensils and their corresponding timestamps
                            for (int i = 0; i < recipe.UtensilToTimestamp.Count; i++) {
                                cmd.CommandText = "INSERT INTO RecipeUtensil(RecipeID, UtensilID, BeginTime, EndTime) " +
                                                  "VALUES (@RecipeID, @UtensilID, @BeginTime, @EndTime";

                                // Second loop that executes the insert as many times as the ingredient was used in the recipe 
                                // I.e. Insert the same ingredient with different timestamps if it was used more than once
                                for (int j = 0; j < recipe.UtensilToTimestamp.ElementAt(i).Value.Count; j++) {
                                    cmd.Parameters.AddWithValue("@RecipeID", recipeId);
                                    cmd.Parameters.AddWithValue("@IngredientID", recipe.UtensilToTimestamp.ElementAt(i).Key.Id);
                                    cmd.Parameters.AddWithValue("@BeginTime", recipe.UtensilToTimestamp.ElementAt(i).Value[j].StartTime);
                                    cmd.Parameters.AddWithValue("@EndTime", recipe.UtensilToTimestamp.ElementAt(i).Value[j].EndTime);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // After all the inserts, commit them to the database
                            transaction.Commit();
                        } catch {
                            transaction.Rollback();
                        }
                    }
                }
            } catch (Exception ex ) {
                throw new RecipeRepositoryException("An error occurred. The recipe was not added to the database.");
            }
        }
    }
}
