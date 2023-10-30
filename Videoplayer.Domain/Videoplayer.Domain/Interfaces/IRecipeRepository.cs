using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 

public interface IRecipeRepository {
    List<Recipe> GetAllRecipes();
    List<Recipe> GetFilteredRecipes(string filter);
    Recipe GetRecipeById(int id); 
  
    //TODO Creating recipes throws errors..fix it
    void CreateRecipe(Recipe recipe);
    // TODO Removing recipes throws errors if recipe has constraints..fix it
    void RemoveRecipe(int id);

    // TODO New method declarations for adding, removing and updating ingredients and utensils in recipes
    // void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient, Timestamp timestamp);
    //
    // void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp);
    // // Dictionary<Ingredient, List<Timestamp>> GetIngredientsWithTimestamps(int recipeId);
    // // Dictionary<Utensil, List<Timestamp>> GetUtensilsWithTimestamps(int recipeId);
    // void RemoveIngredientFromRecipe(int recipeId, int ingredientId);
    // void UpdateIngredientTimestamp(int recipeId, int ingredientId, Timestamp oldTimestamp, Timestamp newTimestamp);

        }