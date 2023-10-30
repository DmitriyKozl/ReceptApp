﻿using VideoplayerProject.Domain.Models;

namespace VideoplayerProject.Domain.Interfaces; 
public interface IIngredientService {
    public List<Ingredient> GetFilteredIngredients(string filter);
    public List<Ingredient> GetAllIngredients();    
    public Ingredient GetIngredientById(int id);
    public List<Ingredient> GetIngredientsFromRecipe(int recipeId);
    
    void CreateIngredient(Ingredient ingredient);
    
    public void RemoveIngredient(int id);
    
    //TODO: Add methods for updating ingredients
}