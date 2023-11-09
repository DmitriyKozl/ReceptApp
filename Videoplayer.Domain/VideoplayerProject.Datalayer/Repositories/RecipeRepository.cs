using Microsoft.EntityFrameworkCore;
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

    public List<Domain.Models.Recipe> GetAllRecipes() {
        return _context.Recipes
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.RecipeUtensils)
            .ThenInclude(ru => ru.Utensil)
            .AsNoTracking()
            .Select(r => RecipeMapper.MapToDomainModel(r))
            .ToList();
    }

    public List<Domain.Models.Recipe> GetFilteredRecipes(string filter) {
        return _context.Recipes
            .Where(r => string.IsNullOrEmpty(filter) || r.RecipeName.Contains(filter))
            .Select(r => RecipeMapper.MapToDomainModel(r))
            .ToList();
    }

    public Domain.Models.Recipe GetRecipeById(int id) {
        var dataRecipe = _context.Recipes
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.RecipeUtensils)
            .ThenInclude(ru => ru.Utensil)
            .AsNoTracking()
            .FirstOrDefault(r => r.RecipeID == id);

        if (dataRecipe == null) return null;

        return RecipeMapper.MapToDomainModel(dataRecipe);
    }

    public void CreateRecipe(Domain.Models.Recipe domainRecipe) {
        if (domainRecipe == null) throw new ArgumentNullException(nameof(domainRecipe));
        if (ExistingRecipe(domainRecipe.VideoLink)) throw new MapperException($"{domainRecipe.Name} already exists.");

        try {
            _context.Recipes.Add(RecipeMapper.MapToDataEntity(domainRecipe, _context));
            SaveAndClear();
        }
        catch (Exception e) {
            throw new MapperException("CreateRecipe failed", e);
        }
    }


    public void RemoveRecipe(int id) {
        var recipe = _context.Recipes
            .Include(r => r.RecipeIngredients)
            .Include(r => r.RecipeUtensils)
            .FirstOrDefault(r => r.RecipeID == id);

        if (!recipe.RecipeIngredients.Any()) {
            throw new MapperException("No Recipe found with that id");
        }

        _context.RecipeIngredient.RemoveRange(recipe.RecipeIngredients);
        _context.RecipeUtensils.RemoveRange(recipe.RecipeUtensils);
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
    }



    public void AddIngredientWithTimeStamp(Recipe recipe, Ingredient ingredient, Timestamp timestamp) 
    {
        if (recipe == null) throw new ArgumentNullException(nameof(recipe));

        // Check if ingredient exists
        var existingRecipeIngredient = _context.RecipeIngredient
            .FirstOrDefault(ri => ri.RecipeID == recipe.Id
                                  && ri.IngredientID == ingredient.Id
                                  && ri.BeginTime == timestamp.StartTime);

        if (existingRecipeIngredient == null) {
            var recipeIngredient = new RecipeIngredient
            { RecipeID = recipe.Id,
              IngredientID = ingredient.Id,
              BeginTime = timestamp.StartTime,
              EndTime = timestamp.EndTime };
            _context.RecipeIngredient.Add(recipeIngredient);
            _context.SaveChanges();
        }
    }
}

/*
 * TODO - UpdateRecipe
 * 1. Update recipe properties
 * 2. Update recipe ingredients
 * 3. Update recipe utensils


    public void UpdateRecipe(int id, Domain.Models.Recipe updatedDomainRecipe) {
        var recipe = _context.Recipes.Find(id);
        if (recipe == null) {
            Console.WriteLine("Recipe not found");
            return;
        }

        // Update properties using the mapper
        var updatedDataRecipe = RecipeMapper.MapToDataEntity(updatedDomainRecipe, _context);
        _context.Entry(recipe).CurrentValues.SetValues(updatedDataRecipe);
        _context.SaveChanges();
    }





public void AddUtensilWithTimeStamp(Domain.Models.Recipe recipe, Utensil utensil, Timestamp timestamp)
    {
        // Check if utensil exists
        var existingRecipeUtensil = _context.RecipeUtensils
            .FirstOrDefault(ru => ru.RecipeID == recipe.Id
                                  && ru.UtensilID == utensil.Id
                                  && ru.BeginTime == timestamp.StartTime);

        if (existingRecipeUtensil == null)
        {
            var recipeUtensil = new RecipeUtensil
            {
            RecipeID = recipe.Id,
            UtensilID = utensil.Id ,
            BeginTime = timestamp.StartTime,
            EndTime = timestamp.EndTime
            };
            _context.RecipeUtensils.Add(recipeUtensil);
            _context.SaveChanges();
        }
    }


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