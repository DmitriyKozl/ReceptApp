using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Repositories;
using VideoplayerProject.Domain.Interfaces;

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
        // Arrange
        var filter = "FilterKeyword";

        // Act
        var result = _utensilsRepository.GetUtensils(filter);

        // Assert
        Assert.NotNull(result);
        // Add assertions based on your specific filter criteria
    }

    [Fact]
    public void GetUtensilsFromRecipe_ShouldReturnUtensilsForRecipe()
    {
        // Arrange
        var recipeId = 1; // Replace with an actual recipe ID

        // Act
        var result = _utensilsRepository.GetUtensilsFromRecipe(recipeId);

        // Assert
        Assert.NotNull(result);
        // Add assertions based on the expected utensils for the given recipe
    }

    [Fact]
    public void GetUtensilById_ShouldReturnUtensil()
    {
        // Arrange
        var utensilId = 1; // Replace with an actual utensil ID

        // Act
        var result = _utensilsRepository.GetUtensilById(utensilId);

        // Assert
        Assert.NotNull(result);
        // Add more assertions based on the expected utensil properties
    }


}