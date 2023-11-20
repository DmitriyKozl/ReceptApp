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

        var result = _recipeRepository.GetRecipeById(existingRecipeId);

        Assert.Null(result);
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

        Assert.Throws<MapperException>(() => _recipeRepository.CreateRecipe(duplicateRecipe));
    }

}
