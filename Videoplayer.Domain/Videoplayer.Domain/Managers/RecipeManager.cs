using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public void CreateRecipe(Recipe recipe) {
        _recipeRepository.CreateRecipe(recipe);
    }

    public void RemoveRecipe(int id) {
        _recipeRepository.RemoveRecipe(id);
    }

/* TODO implement this
    public void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient, Timestamp timestamp) {
        if (!recipe.IngredientToTimestamp.ContainsKey(ingredient)) {
            recipe.IngredientToTimestamp[ingredient] = new List<Timestamp>();
        }

        recipe.IngredientToTimestamp[ingredient].Add(timestamp);

        _recipeRepository.UpdateRecipe(recipe.Id, recipe);
    }

    public void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp) {
        if (!recipe.UtensilToTimestamp.ContainsKey(utensil)) {
            recipe.UtensilToTimestamp[utensil] = new List<Timestamp>();
        }

        recipe.UtensilToTimestamp[utensil].Add(timestamp);

        _recipeRepository.UpdateRecipe(recipe.Id, recipe);
    }

    public void RemoveIngredientFromRecipe(int recipeId, Ingredient ingredient) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null || !recipe.IngredientToTimestamp.ContainsKey(ingredient))
            throw new RecipeException("Ingredient not found in the recipe");

        recipe.IngredientToTimestamp.Remove(ingredient);
        _recipeRepository.UpdateRecipe(recipeId, recipe);
    }

    public void UpdateIngredientTimestamp(int recipeId, Ingredient ingredient, Timestamp oldTimestamp,
        Timestamp newTimestamp) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null || !recipe.IngredientToTimestamp.ContainsKey(ingredient)
                           || !recipe.IngredientToTimestamp[ingredient].Remove(oldTimestamp))
            throw new RecipeException("Ingredient or timestamp not found in the recipe");

        recipe.IngredientToTimestamp[ingredient].Add(newTimestamp);
        _recipeRepository.UpdateRecipe(recipeId, recipe);
    }

    public Dictionary<Ingredient, List<Timestamp>> GetIngredientsWithTimestamps(int recipeId) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null)
            throw new RecipeException("Recipe not found");
        return recipe.IngredientToTimestamp;
    }

    public Dictionary<Utensil, List<Timestamp>> GetUtensilsWithTimestamps(int recipeId) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null)
            throw new RecipeException("Recipe not found");
        return recipe.UtensilToTimestamp;
    }
    */
}