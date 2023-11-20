﻿using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Mappers;
using VideoplayerProject.Datalayer.Exceptions;
using VideoplayerProject.Datalayer.Models;
using VideoplayerProject.Domain.Models;
using Ingredient = VideoplayerProject.Domain.Models.Ingredient;
using IRecipeRepository = VideoplayerProject.Domain.Interfaces.IRecipeRepository;
using Recipe = VideoplayerProject.Domain.Models.Recipe;

namespace VideoplayerProject.Datalayer.Repositories;

public class RecipeRepository : IRecipeRepository {
    private readonly RecipeDbContext _context;

    public RecipeRepository(RecipeDbContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));

    }

    private void SaveAndClear() {
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public bool ExistingRecipe(string videolink) {
        return _context.Recipes.Any(r => r.VideoLink == videolink);
    }

    public List<Recipe> GetRecipes(string? filter = null)
    {
        try
        {
            var query = _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeUtensils)
                .ThenInclude(ru => ru.Utensil)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(r => r.RecipeName.Contains(filter));
            }

            return query
                .Select(r => RecipeMapper.MapToDomainModel(r))
                .ToList();
        }
        catch (Exception ex)
        {
            throw new RecipeRepositoryException("Error in GetRecipes. ", ex);
        }

    }


    public Recipe GetRecipeById(int id) {
        try
        {
            var dataRecipe = _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeUtensils)
                .ThenInclude(ru => ru.Utensil)
                .AsNoTracking()
                .FirstOrDefault(r => r.RecipeID == id);

            if (dataRecipe == null) throw new ArgumentNullException($"No Recipe with id {id}");

            return RecipeMapper.MapToDomainModel(dataRecipe);
        }
        catch (Exception ex)
        {
            throw new RecipeRepositoryException("Error in GetRecipeById. ", ex);
        }

    }

    public void CreateRecipe(Recipe domainRecipe) {
        try
        {
            if (domainRecipe == null) throw new ArgumentNullException(nameof(domainRecipe));
            if (ExistingRecipe(domainRecipe.VideoLink)) throw new MapperException($"{domainRecipe.Name} already exists.");

            _context.Recipes.Add(RecipeMapper.MapToDataEntity(domainRecipe, _context));
            SaveAndClear();
        }
        catch (Exception ex)
        {
            throw new RecipeRepositoryException("Error creating recipe. ", ex);
        }
    }


    public void RemoveRecipe(int id) {
        try
        {
            var recipe = _context.Recipes
                .Include(r => r.RecipeIngredients)
                .Include(r => r.RecipeUtensils)
                .FirstOrDefault(r => r.RecipeID == id);

            if (recipe == null) throw new RecipeRepositoryException("No recipe found");

            _context.RecipeIngredient.RemoveRange(recipe.RecipeIngredients);
            _context.RecipeUtensils.RemoveRange(recipe.RecipeUtensils);
            _context.Recipes.Remove(recipe);
            SaveAndClear();
        }
        catch (Exception ex)
        {
            throw new RecipeRepositoryException("Error removing recipe. ", ex);
        }
    }


    public void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient, Timestamp timestamp) {
        try
        {
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));

            // Check if ingredient exists
            var existingRecipeIngredient = _context.RecipeIngredient
                .FirstOrDefault(ri => ri.RecipeID == recipe.Id
                                      && ri.IngredientID == ingredient.Id
                                      && ri.BeginTime == timestamp.StartTime);

            if (existingRecipeIngredient == null)
            {
                var recipeIngredient = new RecipeIngredient
                {
                    RecipeID = recipe.Id,
                    IngredientID = ingredient.Id,
                    BeginTime = timestamp.StartTime,
                    EndTime = timestamp.EndTime
                };
                _context.RecipeIngredient.Add(recipeIngredient);
                SaveAndClear();
            }
        }
        catch (Exception ex)
        {
            throw new RecipeRepositoryException("Error in AddIngredientWithTimeStamp. ", ex);
        }
    }

    public void AddUtensilWithTimeStamp(Recipe recipe, Utensil utensil, Timestamp timestamp) {
        try
        {
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));

            // Check if ingredient exists
            var existingRecipeUtensil = _context.RecipeUtensils
                .FirstOrDefault(ri => ri.RecipeID == recipe.Id
                                      && ri.UtensilID == utensil.Id
                                      && ri.BeginTime == timestamp.StartTime);

            if (existingRecipeUtensil == null)
            {
                var recipeUtensil = new RecipeUtensil
                {
                    RecipeID = recipe.Id,
                    UtensilID = utensil.Id,
                    BeginTime = timestamp.StartTime,
                    EndTime = timestamp.EndTime
                };
                _context.RecipeUtensils.Add(recipeUtensil);
                SaveAndClear();
            }
        }
        catch (Exception ex)
        {
            throw new RecipeRepositoryException("Error in AddUtensilWithTimeStamp. ", ex);
        }
    }

    public void UpdateRecipe(Domain.Models.Recipe updatedDomainRecipe) {
        
        try 
        {
            _context.Recipes.Update(RecipeMapper.MapToDataEntity(updatedDomainRecipe, _context));
            SaveAndClear();
        }
        catch (Exception ex)
        {
            throw new RecipeRepositoryException("Error in UpdateRecipe. ", ex);
        }
    }

   public Ingredient GetIngredientsWithTimestamps(int recipeId, int ingredientId) {
       try
       {
           var recipeIngredient = _context.RecipeIngredient
               .Include(ri => ri.Ingredient)
               .FirstOrDefault(ri => ri.RecipeID == recipeId && ri.IngredientID == ingredientId);

           if (recipeIngredient == null) throw new ArgumentNullException(nameof(recipeIngredient));

           return IngredientMapper.MapToDomainModel(recipeIngredient.Ingredient);
       }
       catch (Exception ex)
       {
           throw new RecipeRepositoryException("Error in GetIngredientsWithTimestamps. ", ex);
       }

    }   
   public Utensil GetUtensilWithTimestamps(int recipeId, int UtensilId) {
       try
       {
           var recipeUtensil = _context.RecipeUtensils
               .Include(ri => ri.Utensil)
               .FirstOrDefault(ri => ri.RecipeID == recipeId && ri.UtensilID == UtensilId);

           if (recipeUtensil == null) throw new ArgumentNullException(nameof(recipeUtensil));

           return UtensilMapper.MapToDomainModel(recipeUtensil.Utensil);
       }
       catch (Exception ex)
       {
           throw new RecipeRepositoryException("Error in GetUtensilWithTimeStamps. ", ex);
       }
    }
}
/*
 * TODO - UpdateRecipe
 * 1. Update recipe properties
 * 2. Update recipe ingredients
 * 3. Update recipe utensils



    public void RemoveIngredientFromRecipe(int recipeId, int ingredientId) {
        var recipeIngredient = _context.RecipeIngredient
            .FirstOrDefault(ri => ri.RecipeID == recipeId && ri.IngredientID == ingredientId);

        if (recipeIngredient == null) throw new ArgumentNullException(nameof(recipeIngredient));

        _context.RecipeIngredient.Remove(recipeIngredient);
        _context.SaveChanges();
    }

    public void UpdateIngredientTimestamp(int recipeId, int ingredientId, Timestamp oldTimestamp,
        Timestamp newTimestamp) {
        var recipeIngredient = _context.RecipeIngredient
            .FirstOrDefault(ri => ri.RecipeID == recipeId && ri.IngredientID == ingredientId);

        if (recipeIngredient == null) throw new ArgumentNullException(nameof(recipeIngredient));

        recipeIngredient.BeginTime = newTimestamp.StartTime;
        recipeIngredient.EndTime = newTimestamp.EndTime;
        _context.SaveChanges();
    }

    private void UpdateRecipeIngredients(Domain.Models.Recipe domainRecipe, Datalayer.Models.Recipe dataRecipe) {
        // Handle additions and updates
        foreach (var domainIngredient in domainRecipe.IngredientToTimestamp) {
            var dataIngredient = dataRecipe.RecipeIngredients
                .FirstOrDefault(ri => ri.IngredientID == domainIngredient.Key.Id);

            if (dataIngredient == null) {
                // Add new ingredient
                dataRecipe.RecipeIngredients.Add(new RecipeIngredient
                { RecipeID = dataRecipe.RecipeID,
                  IngredientID = domainIngredient.Key.Id,
                  BeginTime = domainIngredient.Value.Min(t => t.StartTime),
                  EndTime = domainIngredient.Value.Max(t => t.EndTime) });
            }
            else {
                // Update existing ingredient
                dataIngredient.BeginTime = domainIngredient.Value.Min(t => t.StartTime);
                dataIngredient.EndTime = domainIngredient.Value.Max(t => t.EndTime);
            }
        }

        var domainIngredientIds = domainRecipe.IngredientToTimestamp.Keys.Select(i => i.Id).ToList();
        dataRecipe.RecipeIngredients
            .Where(ri => !domainIngredientIds.Contains(ri.IngredientID))
            .ToList()
            .ForEach(riToDelete => dataRecipe.RecipeIngredients.Remove(riToDelete));
    }

    private void UpdateRecipeUtensils(Domain.Models.Recipe domainRecipe, Datalayer.Models.Recipe dataRecipe) {
        // Handle additions and updates
        foreach (var domainUtensil in domainRecipe.UtensilToTimestamp) {
            var dataUtensil = dataRecipe.RecipeUtensils
                .FirstOrDefault(ru => ru.UtensilID == domainUtensil.Key.Id);

            if (dataUtensil == null) {
                // Add new utensil
                dataRecipe.RecipeUtensils.Add(new RecipeUtensil
                { RecipeID = dataRecipe.RecipeID,
                  UtensilID = domainUtensil.Key.Id,
                  BeginTime = domainUtensil.Value.Min(t => t.StartTime),
                  EndTime = domainUtensil.Value.Max(t => t.EndTime) });
            }
            else {
                // Update existing utensil
                dataUtensil.BeginTime = domainUtensil.Value.Min(t => t.StartTime);
                dataUtensil.EndTime = domainUtensil.Value.Max(t => t.EndTime);
            }
        }
        // Handle deletions
        var domainUtensilIds = domainRecipe.UtensilToTimestamp.Keys.Select(u => u.Id).ToList();
        dataRecipe.RecipeUtensils
            .Where(ru => !domainUtensilIds.Contains(ru.UtensilID))
            .ToList()
            .ForEach(ruToDelete => dataRecipe.RecipeUtensils.Remove(ruToDelete));
    }
} */