using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces;

public interface IRecipeService {
    List<Recipe> GetRecipes(string? filter = null);
    Recipe GetRecipeById(int id);

    Recipe CreateRecipe(Recipe recipe);
    bool ExistingRecipe(string videolink);

    void RemoveRecipe(int id);

    public void AddIngredientWithTimeStamp(Domain.Models.Recipe recipe, Domain.Models.Ingredient ingredient,
        Timestamp timestamp);
    public void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp);
    public Recipe UpdateRecipe(Recipe recipe);
    
    Ingredient GetIngredientsWithTimestamps(int recipeId, int ingredientId);
    Utensil GetUtensilWithTimestamps(int recipeId, int utensilId);


    
    
    // TODO: Add UpdateRecipe method
    //
    // void RemoveIngredientFromRecipe(int recipeId, Ingredient ingredient);
    // void UpdateIngredientTimestamp(int recipeId, Ingredient ingredient, Timestamp oldTimestamp, Timestamp newTimestamp);
}