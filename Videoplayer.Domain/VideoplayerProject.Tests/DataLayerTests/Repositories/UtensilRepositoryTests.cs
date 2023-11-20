using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Exceptions;
using VideoplayerProject.Datalayer.Repositories;
using VideoplayerProject.Domain.Interfaces;
namespace VideoplayerProject.Tests.DataLayerTests.Repositories;

public class UtensilsRepositoryTests
{
    private readonly RecipeDbContext _dbContext;
    private readonly UtensilsRepository _utensilsRepository;

    public UtensilsRepositoryTests()
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
        _utensilsRepository = new UtensilsRepository(_dbContext);
    }

    [Fact]
    public void GetAllUtensils_ShouldReturnAllUtensils()
    {
        var result = _utensilsRepository.GetUtensils();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(_dbContext.Utensils.Count(), result.Count);
    }

    [Fact]
    public void GetUtensils_ShouldReturnFilteredUtensils()
    {
        var filter = "Utensil2";

        var result = _utensilsRepository.GetUtensils(filter);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(result.All(utensil => utensil.Name.Contains(filter)));
    }


    [Fact]
    public void GetUtensilsFromRecipe_ShouldReturnUtensilsForRecipe()
    {
        var recipeId = 1;

        var result = _utensilsRepository.GetUtensilsFromRecipe(recipeId);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetUtensilById_ShouldReturnUtensilForValidId()
    {
        var utensilId = 1;

        var result = _utensilsRepository.GetUtensilById(utensilId);

        Assert.NotNull(result);
    }

    [Fact]
    public void GetUtensilById_ShouldThrowExceptionForInvalidId()
    {
        var invalidUtensilId = 999;

        Assert.Throws<UtensilRepositoryException>(() => _utensilsRepository.GetUtensilById(invalidUtensilId));
    }

    [Fact]
    public void CreateUtensil_ShouldAddNewUtensil()
    {
        var newUtensil = new DomainUtensil("NewUtensil", "NewTestImg");

        _utensilsRepository.CreateUtensil(newUtensil);

        var result = _dbContext.Utensils.FirstOrDefault(u => u.UtensilName == newUtensil.Name);
        Assert.NotNull(result);
        Assert.Equal(newUtensil.Name, result.UtensilName);
    }

    [Fact]
    public void UpdateUtensil_ShouldUpdateExistingUtensil()
    {
        var existingUtensil = _dbContext.Utensils.First();
        var updatedDomainUtensil = new DomainUtensil(existingUtensil.UtensilID,"NewUtensil", "NewTestImg");


        _utensilsRepository.UpdateUtensil(updatedDomainUtensil);

        var result = _dbContext.Utensils.Find(existingUtensil.UtensilID);
        Assert.NotNull(result);
        Assert.Equal(updatedDomainUtensil.Name, result.UtensilName);
        Assert.Equal(updatedDomainUtensil.ImgUrl, result.ImgUrl);
    }

    [Fact]
    public void UpdateUtensil_ShouldThrowExceptionForNonExistingUtensil()
    {
        var nonExistingUtensil = new DomainUtensil(999, "NonExistingUtensil", "imgurl");

        Assert.Throws<UtensilRepositoryException>(() => _utensilsRepository.UpdateUtensil(nonExistingUtensil));
    }
}