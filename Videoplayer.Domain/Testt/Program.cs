using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Models;
using VideoplayerProject.Datalayer.Repositories;
using VideoplayerProject.Domain.Managers;
using VideoplayerProject.Domain.Models;
using Ingredient = VideoplayerProject.Domain.Models.Ingredient;

namespace Testt
{
    internal class Program
    {
        Ingredient I {  get; set; }
        IngredientManager iManager { get; set; }
        RecipeDbContext dbContext { get; set; }

    static void Main(string[] args)
        {

            var options = new DbContextOptionsBuilder<RecipeDbContext>()
                .UseSqlServer("Server = tcp:receptendb.database.windows.net,1433; Initial Catalog = receptdb; Persist Security Info = False; User ID = receptdblogin; Password = qLW7yJZHyNU4zJP; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ") // Specify your database connection string
                .Options;
            RecipeDbContext dbContext = new RecipeDbContext(options);
            RecipeManager rManager = new RecipeManager(new RecipeRepository(dbContext));
            IngredientManager iManager = new IngredientManager(new IngredientRepository(dbContext));


           foreach(Ingredient i in iManager.GetAllIngredients())
            {
                Console.WriteLine(i.Name,i.Id);
            }
            rManager.RemoveRecipe(2);
        }

    }
}