using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 

public interface IRecipeRepository {
    List<Recipe> GetAllRecipes();
    List<Recipe> GetFilteredRecipes(string filter);
    Recipe GetRecipeById(int id); 
    bool ExistingRecipe(string videolink);
    void CreateRecipe(Recipe recipe);
    void RemoveRecipe(int id);
    public void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient,  Timestamp timestamp);
   
    // void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp);
    // // Dictionary<Ingredient, List<Timestamp>> GetIngredientsWithTimestamps(int recipeId);
    // // Dictionary<Utensil, List<Timestamp>> GetUtensilsWithTimestamps(int recipeId);
    // void RemoveIngredientFromRecipe(int recipeId, int ingredientId);
    // void UpdateIngredientTimestamp(int recipeId, int ingredientId, Timestamp oldTimestamp, Timestamp newTimestamp);

        }