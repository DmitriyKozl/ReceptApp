using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces;

public interface IRecipeService {
    List<Recipe> GetAllRecipes();
    List<Recipe> GetFilteredRecipes(string filter);
    Recipe GetRecipeById(int id);

    Recipe CreateRecipe(Recipe recipe);
    bool ExistingRecipe(string videolink);

    void RemoveRecipe(int id);

    public void AddIngredientWithTimeStamp(Domain.Models.Recipe recipe, Domain.Models.Ingredient ingredient,
        Timestamp timestamp);
    public void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp);

    
    
    // TODO: Add UpdateRecipe method
    // void UpdateRecipe(int id, Recipe recipe);
    //
    // void RemoveIngredientFromRecipe(int recipeId, Ingredient ingredient);
    // void UpdateIngredientTimestamp(int recipeId, Ingredient ingredient, Timestamp oldTimestamp, Timestamp newTimestamp);
}