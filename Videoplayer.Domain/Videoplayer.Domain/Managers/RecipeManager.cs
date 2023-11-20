
using VideoplayerProject.Domain.Exceptions;
using VideoplayerProject.Domain.Interfaces;
using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Managers;

public class RecipeManager : IRecipeService {
    private IRecipeRepository _recipeRepository;

    public RecipeManager(IRecipeRepository recipeRepository) {
        _recipeRepository = recipeRepository;
    }

    public List<Recipe> GetRecipes(string? filter = null) {
        return _recipeRepository.GetRecipes(filter);
    }

    public Recipe GetRecipeById(int id) {
        return _recipeRepository.GetRecipeById(id);
    }
    
    public Ingredient GetIngredientsWithTimestamps(int recipeId, int ingredientId) {
        return _recipeRepository.GetIngredientsWithTimestamps(recipeId, ingredientId);
    }
    public Utensil GetUtensilWithTimestamps(int recipeId, int utensilId) {
        return _recipeRepository.GetUtensilWithTimestamps(recipeId, utensilId);
    }

    public Recipe CreateRecipe(Recipe recipe) {
        if (recipe == null) throw new ArgumentNullException(nameof(recipe));
        if (ExistingRecipe(recipe.VideoLink)) throw new RecipeException($"{recipe.Name} already exists.");
        _recipeRepository.CreateRecipe(recipe);
        return recipe;
    }

    public bool ExistingRecipe(string videolink) {
        return _recipeRepository.GetRecipes().Find(r =>r.VideoLink == videolink) != null;
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
    
    public Recipe UpdateRecipe(Recipe recipe) {
        try
        {
            if (recipe == null) throw new RecipeException("Updaterecipe - recipe is null");
            if (!_recipeRepository.ExistingRecipe(recipe.VideoLink)) throw new RecipeException("Updaterecipe - recipe with this video exists already");
            Recipe recipeDB = _recipeRepository.GetRecipeById(recipe.Id);
            if (recipe == recipeDB) throw new RecipeException("Updaterecipe - geen verschillen");
            _recipeRepository.UpdateRecipe(recipe);
            return recipe;
        }
        catch(Exception ex)
        {
            throw new RecipeException("Updaterecipe", ex);
        }    }
    

}