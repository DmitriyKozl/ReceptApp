using System.Data.SqlClient;
using System.Data;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Datalayer.Repositories
{
    public class IngredientRepository : IIngredientRepository {
        private string connectionString;
        public IngredientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Ingredient> GetIngredients(string filter)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT IngredientID, IngredientName, Price, Brand FROM Ingredients";

                    if (!string.IsNullOrEmpty(filter))
                    {
                        query += " WHERE IngredientName LIKE @filter";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(filter))
                        {
                            command.Parameters.Add(new SqlParameter("@filter", SqlDbType.NVarChar, 255)).Value = "%" + filter + "%";
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = (string)reader["IngredientName"];
                                string brand = (string)reader["Brand"];
                                int id = (int)reader["Brand"];
                                decimal price = (decimal)reader["Price"];
                                ingredients.Add(new Ingredient(id,name,price, brand));
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return ingredients;
        }

        public List<Ingredient> GetIngredientsFromRecipe(int recipeId)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Ingredients.* " +
                                   "FROM Ingredients " +
                                   "JOIN RecipeIngredient ON Ingredients.IngredientID = RecipeIngredient.IngredientID " +
                                   "WHERE RecipeIngredient.RecipeID = @RecipeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeID", recipeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = (string)reader["IngredientName"];
                                string brand = (string)reader["Brand"];
                                int id = (int)reader["Brand"];
                                decimal price = (decimal)reader["Price"];
                                ingredients.Add(new Ingredient(id, name, price, brand));
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            return ingredients;
        }
        public void AddIngredient(string name, string brand)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Ingredients (IngredientName, Brand) VALUES (@IngredientName, @Brand)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IngredientName", name);
                        command.Parameters.AddWithValue("@Brand", brand);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }

            }
        }
        public void RemoveIngredient(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM Ingredients WHERE IngredientID = @IngredientID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IngredientID", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void UpdateIngredient(int id, string newName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Ingredients SET IngredientName = @NewName WHERE IngredientID = @IngredientID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewName", newName);
                        command.Parameters.AddWithValue("@IngredientID", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}