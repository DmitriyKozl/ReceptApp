using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces;

public interface IRecipeService {
    List<Recipe> GetAllRecipes();
    List<Recipe> GetFilteredRecipes(string filter);
    Recipe GetRecipeById(int id);
    
    void CreateRecipe(Recipe recipe);
    
    void RemoveRecipe(int id);
    
    // TODO: Add UpdateRecipe method
    // void UpdateRecipe(int id, Recipe recipe);
    //
    // void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient, Timestamp timestamp);
    // void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp);
    // void RemoveIngredientFromRecipe(int recipeId, Ingredient ingredient);
    // void UpdateIngredientTimestamp(int recipeId, Ingredient ingredient, Timestamp oldTimestamp, Timestamp newTimestamp);
}