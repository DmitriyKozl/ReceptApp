using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 

public interface IRecipeRepository {
    List<Recipe> GetAllRecipes();
    List<Recipe> GetFilteredRecipes(string filter);
    Recipe GetRecipeById(int id);
    Utensil GetUtensilWithTimestamps(int recipeId, int utensilId);
    Ingredient GetIngredientsWithTimestamps(int recipeId, int ingredientId);

    bool ExistingRecipe(string videolink);
    void CreateRecipe(Recipe recipe);
    void RemoveRecipe(int id);
    void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient,  Timestamp timestamp);
    void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp);
    
    void UpdateRecipe(Recipe recipe);
    

    // // Dictionary<Utensil, List<Timestamp>> GetUtensilsWithTimestamps(int recipeId);
    // void RemoveIngredientFromRecipe(int recipeId, int ingredientId);
    // void UpdateIngredientTimestamp(int recipeId, int ingredientId, Timestamp oldTimestamp, Timestamp newTimestamp);

        }