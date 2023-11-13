
using VideoplayerProject.Domain.Exceptions;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers;

public class RecipeManager : IRecipeService {
    private IRecipeRepository _recipeRepository;

    public RecipeManager(IRecipeRepository recipeRepository) {
        _recipeRepository = recipeRepository;
    }

    public List<Recipe> GetAllRecipes() {
        return _recipeRepository.GetAllRecipes();
    }

    public List<Recipe> GetFilteredRecipes(string filter) {
        return _recipeRepository.GetFilteredRecipes(filter);
    }

    public Recipe GetRecipeById(int id) {
        return _recipeRepository.GetRecipeById(id);
    }

    public Recipe CreateRecipe(Recipe recipe) {
        if (recipe == null) throw new ArgumentNullException(nameof(recipe));
        if (ExistingRecipe(recipe.VideoLink)) throw new RecipeException($"{recipe.Name} already exists.");
        _recipeRepository.CreateRecipe(recipe);
        return recipe;
    }

    public bool ExistingRecipe(string videolink) {
        return _recipeRepository.GetAllRecipes().Any(r => r.VideoLink == videolink);
    }

    public void RemoveRecipe(int id) {
        _recipeRepository.RemoveRecipe(id);
    }

    public void AddIngredientWithTimeStamp(Domain.Models.Recipe recipe, Domain.Models.Ingredient ingredient,
        Timestamp timestamp) {
        _recipeRepository.AddIngredientWithTimeStamp(recipe, ingredient, timestamp);
    }    
    public void AddUtensilWithTimeStamp(Domain.Models.Recipe recipe, Domain.Models.Utensil utensil,
        Timestamp timestamp) {
        _recipeRepository.AddUtensilWithTimeStamp(recipe, utensil, timestamp);
    }
}