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

        public List<Recipe> GetAllRecipes() {
            try {
                List<Recipe> recipes = new List<Recipe>();

                string sql = "recipename, videourl FROM recipe;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = sql;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read()) {
                            recipes.Add(new((string)reader["RecipeName"],

                                ))
                        }

            } catch (Exception ex) {

                throw new RecipeRepositoryException("Geef Alle recepten error");
            }
        }
    }
}
