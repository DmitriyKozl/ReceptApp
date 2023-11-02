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

//TODO: Implement UpdateRecipe
    
    // INGREDIENT CRUD
    // create
    public void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient, Timestamp timestamp) {
        recipe.AddIngredientWithTimeStampToRecipe(ingredient, timestamp);

        //_recipeRepository.UpdateRecipe(recipe.Id, recipe);
    }

    // read
    public Dictionary<Ingredient, List<Timestamp>> GetIngredientsWithTimestamps(int recipeId) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null)
            throw new RecipeException("Recipe not found");
        return recipe.IngredientToTimestamp;
    }

    // update
    public void UpdateIngredientTimestamp(int recipeId, Ingredient ingredient, Timestamp oldTimestamp,
        Timestamp newTimestamp) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        recipe.UpdateIngredientTimestamp(ingredient, oldTimestamp, newTimestamp);
        //_recipeRepository.UpdateRecipe(recipeId, recipe);
    }

    // delete ingredient and ALL its timestamps
    public void RemoveIngredientFromRecipe(int recipeId, Ingredient ingredient) {
        // Get recipe
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        recipe.RemoveIngredient(ingredient);

        //_recipeRepository.UpdateRecipe(recipeId, recipe);
    }

    // delete specific timestamp for ingredient
    public void RemoveTimestampForIngredient(int recipeId, Ingredient ingredient, Timestamp timestamp) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        recipe.RemoveTimestampForIngredient(ingredient, timestamp);

        //_recipeRepository.UpdateRecipe(recipeId, recipe);
    }

    // TIMESTAMP CRUD
    // create
    public void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp) {
        recipe.AddUtensilWithTimeStampToRecipe(utensil, timestamp);

        //_recipeRepository.UpdateRecipe(recipe.Id, recipe);
    }

    // read
    public Dictionary<Utensil, List<Timestamp>> GetUtensilsWithTimestamps(int recipeId) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null)
            throw new RecipeException("Recipe not found");
        return recipe.UtensilToTimestamp;
    }

    // update
    public void UpdateUtensilTimestamp(int recipeId, Utensil utensil, Timestamp oldTimestamp,
        Timestamp newTimestamp) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        recipe.UpdateUtensilTimestamp(utensil, oldTimestamp, newTimestamp);
        //_recipeRepository.UpdateRecipe(recipeId, recipe);
    }

    // delete utensil and ALL timestamps
    public void RemoveUtensilFromRecipe(int recipeId, Utensil utensil) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        recipe.RemoveUtensil(utensil);
        //_recipeRepository.UpdateRecipe(recipe.Id, recipe);
    }

    // delete specific timestamp for utensil
    public void RemoveTimestampForUtensil(int recipeId, Utensil utensil, Timestamp timestamp) {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        recipe.RemoveTimestampForUtensil(utensil, timestamp);
        //_recipeRepository.UpdateRecipe(recipe.Id, recipe);
    }







}