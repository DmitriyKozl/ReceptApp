using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;
using System.Data;

namespace VideoplayerProject.Datalayer.Repositories
{
    public class UtensilRepository : IUtensilRepository {
        private string connectionString;
        public UtensilRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Utensil> GetAllUtensils(string filter)
        {
            List<Utensil> utensils = new List<Utensil>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UtensilID, UtensilName FROM Utensils";

                    if (!string.IsNullOrEmpty(filter))
                    {
                        query += " WHERE UtensilName LIKE @filter";
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
                                int utensilId = reader.GetInt32(0);
                                string name = reader.GetString(1);

                                utensils.Add(new Utensil { Id = utensilId, Name = name });
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            return utensils;
        }


        public List<Utensil> GetUtensilsFromRecipe(int recipeId)
        {
            List<Utensil> utensils = new List<Utensil>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT U.UtensilID, U.UtensilName FROM Utensils U " +
                           "INNER JOIN RecipeUtensils RU ON U.UtensilID = RU.UtensilID " +
                           "WHERE RU.RecipeID = @recipeId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@recipeId", SqlDbType.Int)).Value = recipeId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int utensilId = reader.GetInt32(0);
                                string name = reader.GetString(1);

                                utensils.Add(new Utensil { Id = utensilId, Name = name });
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            return utensils;
        }

        public void AddUtensil(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Utensil (UtensilID, UtensilName) VALUES (@id, @name)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                        command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 255)).Value = name;
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
        public void RemoveUtensil(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Utensil WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        command.Parameters["@Id"].Value = id;
                        command.ExecuteNonQuery();
                    }
                } catch(SqlException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void UpdateUtensil(int id, string newName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Utensil SET UtensilName = @newName WHERE UtensilID = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@newName", SqlDbType.NVarChar, 255)).Value = newName;
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
