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

                string sql = "SELECT * FROM Recipe;";

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
                                                           (string)reader["VideoUrl"],
                                                           (TimeSpan)reader["CookingTime"]
                                                           );
                                
                                // Get the recipeId to join tables
                                int recipeId = (int)reader["RecipeId"];

                                // Then add all the ingredients with timestamps...
                                string joinCmd = "SELECT BeginTime, EndTime, IngredientName, Price, Brand FROM Recipes" +
                                                 "JOIN RecipeIngredient on Recipes.RecipeID = RecipeIngredient.RecipeID" + 
                                                 "JOIN Ingredients on RecipeIngredient.IngredientID = Ingredients.IngredientID" +
                                                 $"WHERE Recipes.RecipeID = {recipeId};";

                                SqlCommand command = conn.CreateCommand();
                                command.CommandText = joinCmd;

                                using(SqlDataReader dataReader = command.ExecuteReader()) {
                                    if(dataReader.HasRows) {
                                        while(reader.Read()) {
                                            recipe.AddIngredientWithTimeStampToRecipe(new Ingredient(
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
                string sql = $"DELETE FROM recipe WHERE (RecipeName = {recipe.Name} && RecipeUrl = {recipe.VideoLink}";

                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = conn.CreateCommand()) {
                        conn.Open();
                        cmd.CommandText = sql;

                        cmd.ExecuteNonQuery();
                    }
                }

            } catch (Exception ex) {
                throw new RecipeRepositoryException("No recipe found to delete.");
            }
        }

        public void AddRecipe(Recipe recipe) {
            try {
                string sql = $"INSERT INTO recipe (RecipeName, VideoUrl) " +
                             $"VALUES ({recipe.Name}, {recipe.VideoLink});";

                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = conn.CreateCommand()) {
                        conn.Open();

                        SqlTransaction transaction = conn.BeginTransaction();

                        try {
                            // Fist: save the recipe object and get the RecipeId via ExecuteScalar
                            cmd.CommandText = sql;
                            int recipeId = (int)cmd.ExecuteScalar();

                            // Second: Save the corresponding List of Ingredients and their corresponding timestamps
                            for(int i = 0; i < recipe.IngredientToTimestamp.Count; i++) {
                                cmd.CommandText = $"INSERT INTO ingredients(IngredientName, RecipeId) " +
                                                  $"OUTPUT Inserted.Id " +
                                                  $"VALUES ({recipe.IngredientToTimestamp.ElementAt(i).Key.Name}, {recipeId});";
                                cmd.Execute
                            }

                            // Third: Save the corresponding list of utensils and their corresponding timestamps

                            // After all the inserts, commit them to the database
                            transaction.Commit();
                        } catch {
                            transaction.Rollback();
                        }
                    }
                }
            } catch (Exception ex ) {
                throw new RecipeRepositoryException("Recipe was not added to the database.");
            }
        }
    }
}
