using VideoplayerProject.Domain.Models;

namespace Test2 {
    internal class Program {
        static void Main(string[] args) {
            try {
                Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
                Ingredient ingredient = new(1, "spaghetti", 2.0m, "soubry", "testUrl");
                Timestamp existingTimestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);
                Timestamp newTimestampWithSameStarttime = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 30), ingredient.Id);

                // Add the ingredient with timestamp
                recipe.AddIngredientWithTimeStampToRecipe(ingredient, existingTimestamp);

                recipe.AddIngredientWithTimeStampToRecipe(ingredient, newTimestampWithSameStarttime);
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }


        }
    }
}