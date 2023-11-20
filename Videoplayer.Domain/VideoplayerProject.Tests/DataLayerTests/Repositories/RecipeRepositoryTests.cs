using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Exceptions;
using VideoplayerProject.Datalayer.Models;
using VideoplayerProject.Datalayer.Repositories;
using Xunit;
using VideoplayerProject.Datalayer.Mappers;

namespace VideoplayerProject.Tests.DataLayerTests.Repositories;

public class RecipeRepositoryTests
{
    private RecipeDbContext _dbContext;
    private RecipeRepository _recipeRepository;

    public RecipeRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<RecipeDbContext>()
            .UseInMemoryDatabase(databaseName: "test_database" + Guid.NewGuid())
            .Options;

        _dbContext = new RecipeDbContext(options);

        _dbContext.Ingredients.AddRange(new List<DataIngredient>
        {
            new DataIngredient {IngredientID = 1, IngredientName = "Filter1", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 2, IngredientName = "Filter2", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 3, IngredientName = "Filter2", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 4, IngredientName = "Filter3", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 5, IngredientName = "Filter3", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 6, IngredientName = "Filter3", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 7, IngredientName = "Test7", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 8, IngredientName = "Test8", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 9, IngredientName = "Test9", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 10, IngredientName = "Test10", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
        });

        _dbContext.Utensils.AddRange(new List<DataUtensil>
        {
            new DataUtensil {UtensilID = 1, UtensilName = "Utensil1", ImgUrl = "TestImg"},
            new DataUtensil {UtensilID = 2, UtensilName = "Utensil2", ImgUrl = "TestImg"},
            new DataUtensil {UtensilID = 3, UtensilName = "Utensil3", ImgUrl = "TestImg"},
        });

        _dbContext.Recipes.AddRange(new List<DataRecipe>
        {
            new DataRecipe {RecipeID = 1, RecipeName = "Recipe1", Servings = 4, VideoLink = "TestLink", CookingTime = TimeSpan.FromMinutes(30)},
            new DataRecipe {RecipeID = 2, RecipeName = "Recipe2", Servings = 2, VideoLink = "TestLink1", CookingTime = TimeSpan.FromMinutes(45)},
            new DataRecipe {RecipeID = 3, RecipeName = "Recipe3", Servings = 6, VideoLink = "TestLink2", CookingTime = TimeSpan.FromMinutes(60)},
        });


        _dbContext.SaveChanges();
        _recipeRepository = new RecipeRepository(_dbContext);
    }
    [Fact]
    public void ExistingRecipe_ShouldReturnTrue_WhenRecipeExists()
    {
        var videoLink = "TestLink";
        var result = _recipeRepository.ExistingRecipe(videoLink);

        Assert.True(result);
    }

    [Fact]
    public void ExistingRecipe_ShouldReturnFalse_WhenRecipeDoesNotExist()
    {
        var videoLink = "NonExistentLink";
        var result = _recipeRepository.ExistingRecipe(videoLink);

        Assert.False(result);
    }

    [Fact]
    public void GetAllRecipes_ShouldReturnAllRecipes()
    {
        var result = _recipeRepository.GetRecipes();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(_dbContext.Recipes.Count(), result.Count);
    }
    [Fact]
    public void GetRecipes_ShouldReturnFilteredResults()
    {
        var filter = "Recipe2";

        var result = _recipeRepository.GetRecipes(filter);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(result.All(recipe => recipe.Name.Contains(filter)));
    }
    [Fact]
    public void GetRecipeById_ShouldThrowException_WhenInvalidId()
    {
        var invalidRecipeId = int.MaxValue;

        Assert.Throws<RecipeRepositoryException>(() => _recipeRepository.GetRecipeById(invalidRecipeId));
    }
    [Fact]
    public void GetRecipeById_ShouldReturnCorrectRecipe_WithValidId()
    {
        var existingRecipe = _dbContext.Recipes.First();

        var result = _recipeRepository.GetRecipeById(existingRecipe.RecipeID);

        Assert.NotNull(result);
        Assert.Equal(existingRecipe.RecipeID, result.Id);
        Assert.Equal(existingRecipe.RecipeName, result.Name);
        Assert.Equal(existingRecipe.Servings, result.Servings);
        Assert.Equal(existingRecipe.VideoLink, result.VideoLink);
        Assert.Equal(existingRecipe.CookingTime, result.CookingTime);
    }

    [Fact]
    public void CreateRecipe_ShouldAddNewRecipe()
    {
        var newRecipe = new DomainRecipe("DomainName", 1, "Lifenk", new TimeSpan(1));

        _recipeRepository.CreateRecipe(newRecipe);

        var result = _dbContext.Recipes.FirstOrDefault(r => r.RecipeName == newRecipe.Name);

        Assert.NotNull(result);
        Assert.Equal(newRecipe.Name, result.RecipeName);
    }

    [Fact]
    public void UpdateRecipe_ShouldUpdateExistingRecipe()
    {
        var existingRecipe = _dbContext.Recipes.First();
        var updatedDomainRecipe = new DomainRecipe(existingRecipe.RecipeID, "UpdatedRecipe", 3, "UpdatedLink", TimeSpan.FromMinutes(20));
        
        _recipeRepository.UpdateRecipe(updatedDomainRecipe);


        var result = _recipeRepository.GetRecipeById(existingRecipe.RecipeID);

        Assert.NotNull(result);
        Assert.Equal(updatedDomainRecipe.Name, result.Name);
        Assert.Equal(updatedDomainRecipe.Servings, result.Servings);
        Assert.Equal(updatedDomainRecipe.VideoLink, result.VideoLink);
        Assert.Equal(updatedDomainRecipe.CookingTime, result.CookingTime);
    }

    [Fact]
    public void RemoveRecipe_ShouldRemoveExistingRecipe()
    {
        var existingRecipeId = _dbContext.Recipes.First().RecipeID;

        _recipeRepository.RemoveRecipe(existingRecipeId);

        Assert.Throws<RecipeRepositoryException>(() => _recipeRepository.GetRecipeById(existingRecipeId));
    }

    [Fact]
    public void RemoveRecipe_ShouldThrowException_WhenRecipeNotFound()
    {
        var nonExistingRecipeId = int.MaxValue;

        Assert.Throws<RecipeRepositoryException>(() => _recipeRepository.RemoveRecipe(nonExistingRecipeId));
    }

    [Fact]
    public void UpdateRecipe_ShouldThrowException_WhenRecipeNotFound()
    {
        var nonExistingRecipe = new DomainRecipe(999, "NonExistingRecipe", 1, "NonExistingLink", TimeSpan.FromMinutes(10));

        Assert.Throws<RecipeRepositoryException>(() => _recipeRepository.UpdateRecipe(nonExistingRecipe));
    }

    [Fact]
    public void CreateRecipe_ShouldThrowException_WhenRecipeAlreadyExists()
    {
        var existingRecipe = _dbContext.Recipes.First();
        var duplicateRecipe = new DomainRecipe(1, existingRecipe.RecipeName, 1, "DuplicateLink", TimeSpan.FromMinutes(20));

        Assert.Throws<RecipeRepositoryException>(() => _recipeRepository.CreateRecipe(duplicateRecipe));
    }
    [Fact]
    public void GetIngredientsWithTimestamps_ShouldReturnCorrectIngredient()
    {
        var recipeId = 1; 
        var ingredientId = 1;

        _dbContext.RecipeIngredient.Add(new RecipeIngredient
        {
            RecipeID = recipeId,
            IngredientID = ingredientId,
            BeginTime = new TimeSpan(1),  
            EndTime = new TimeSpan(1) 
        });
        var existingIngredient = _dbContext.Ingredients
            .AsNoTracking()
            .FirstOrDefault(i => i.IngredientID == ingredientId);

        Assert.NotNull(existingIngredient);
        _dbContext.SaveChanges();

        var result = _recipeRepository.GetIngredientsWithTimestamps(recipeId, ingredientId);

        Assert.NotNull(result);
        Assert.Equal(ingredientId, result.Id); 
        Assert.Equal("Filter1", result.Name);
        Assert.Equal("TestBrand", result.Brand);
    }
    [Fact]
    public void GetIngredientsWithTimestamps_ShouldThrowException_WhenRecipeIngredientNotFound()
    {
        var recipeId = 1;
        var ingredientId = 1;

        var existingRecipeIngredient = _dbContext.RecipeIngredient
            .FirstOrDefault(ri => ri.RecipeID == recipeId && ri.IngredientID == ingredientId);

        if (existingRecipeIngredient != null)
        {
            _dbContext.RecipeIngredient.Remove(existingRecipeIngredient);
            _dbContext.SaveChanges();
        }

        Assert.Throws<RecipeRepositoryException>(() => _recipeRepository.GetIngredientsWithTimestamps(recipeId, ingredientId));
    }
    [Fact]
    public void GetUtensilsWithTimestamps_ShouldReturnCorrectUtensil()
    {
        var recipeId = 1;
        var utensilId = 1;

        _dbContext.RecipeUtensils.Add(new RecipeUtensil
        {
            RecipeID = recipeId,
            UtensilID = utensilId,
            BeginTime = new TimeSpan(1), 
            EndTime = new TimeSpan(1) 
        });

        var existingUtensil = _dbContext.Utensils
            .AsNoTracking()
            .FirstOrDefault(u => u.UtensilID == utensilId);

        Assert.NotNull(existingUtensil);
        _dbContext.SaveChanges();

        var result = _recipeRepository.GetUtensilWithTimestamps(recipeId, utensilId);

        Assert.NotNull(result);
        Assert.Equal(utensilId, result.Id);
    }
    [Fact]
    public void GetUtensilsWithTimestamps_ShouldThrowException_WhenRecipeUtensilNotFound()
    {
        var recipeId = 1;
        var utensilId = 1;
        var existingRecipeUtensil = _dbContext.RecipeUtensils
            .FirstOrDefault(ru => ru.RecipeID == recipeId && ru.UtensilID == utensilId);

        if (existingRecipeUtensil != null)
        {
            _dbContext.RecipeUtensils.Remove(existingRecipeUtensil);
            _dbContext.SaveChanges();
        }

        Assert.Throws<RecipeRepositoryException>(() => _recipeRepository.GetUtensilWithTimestamps(recipeId, utensilId));
    }

    [Fact]
    public void AddIngredientWithTimeStamp_ShouldAddIngredientWithTimestamp()
    {
        var recipeId = 1;
        var ingredientId = 1;

        var timestamp = new Timestamp(TimeSpan.Zero, TimeSpan.FromMinutes(5), ingredientId);

        var recipe = new DomainRecipe(recipeId, "RecipeName", 4, "TestLink", TimeSpan.FromMinutes(30));
        var ingredient = new DomainIngredient(ingredientId, "TestIngredientName", 1, "TestImg", "");

        _recipeRepository.AddIngredientWithTimeStamp(recipe, ingredient, timestamp);

        var result = _dbContext.RecipeIngredient.FirstOrDefault(ri =>
            ri.RecipeID == recipeId &&
            ri.IngredientID == ingredientId &&
            ri.BeginTime == timestamp.StartTime &&
            ri.EndTime == timestamp.EndTime);

        Assert.NotNull(result);
    }

}

