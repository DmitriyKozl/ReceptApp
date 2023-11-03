using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Models;
using VideoplayerProject.Datalayer.Repositories;
using VideoplayerProject.Domain.Managers;

namespace Testt
{
    internal class Program
    {
        Recipe R {  get; set; }
        Ingredient iI {  get; set; }
        IngredientManager iManager { get; set; }
        RecipeDbContext dbContext { get; set; }

    static void Main(string[] args)
        {
                    Console.WriteLine("Test");

            var options = new DbContextOptionsBuilder<RecipeDbContext>()
                .UseSqlServer("Server = tcp:receptendb.database.windows.net,1433; Initial Catalog = receptdb; Persist Security Info = False; User ID = receptdblogin; Password = qLW7yJZHyNU4zJP; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ") // Specify your database connection string
                .Options;
            RecipeDbContext dbContext = new RecipeDbContext(options);
            RecipeManager rManager = new RecipeManager(new RecipeRepository(dbContext));
            IngredientManager iManager = new IngredientManager(new IngredientRepository(dbContext));


                    Console.WriteLine(iManager.GetIngredientById(1).Name);
                    Console.WriteLine("Test");
            
            rManager.CreateRecipe(new("testttt", 5, "dsfdfs", new TimeSpan(50)) { Id = 5});

                foreach(VideoplayerProject.Domain.Models.Recipe i in rManager.GetAllRecipes())
            {
                Console.WriteLine(i.Name + " " + i.Id) ;
            }

        }
    }
}