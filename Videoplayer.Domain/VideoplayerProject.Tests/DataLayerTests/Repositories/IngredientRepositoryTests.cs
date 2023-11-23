using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Exceptions;
using VideoplayerProject.Datalayer.Repositories;



namespace VideoplayerProject.Tests.DataLayerTests.Repositories;

public class IngredientRepositoryTests
{
    private readonly RecipeDbContext _dbContext;
    private readonly IngredientRepository _ingredientRepository;

    public IngredientRepositoryTests()
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
        _ingredientRepository = new IngredientRepository(_dbContext);
    }

    [Fact]
    public void GetIngredients_ShouldReturnAllIngredients()
    {
        var result = _ingredientRepository.GetIngredients();

        Assert.NotNull(result);
        Assert.Equal(_dbContext.Ingredients.Count(), result.Count);
    }

    [Fact]
    public void GetIngredients_ShouldReturnFilteredIngredients()
    {
        var filter = "Filter2";

        var result = _ingredientRepository.GetIngredients(filter);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(result.All(ingredient => ingredient.Name.Contains(filter)));
    }

    [Fact]
    public void GetIngredientsFromRecipe_ShouldReturnIngredientsFromRecipe()
    {
        var recipeId = 1;

        var result = _ingredientRepository.GetIngredientsFromRecipe(recipeId);

        Assert.NotNull(result);
        Assert.Equal(_dbContext.RecipeIngredient.Count(ri => ri.RecipeID == recipeId), result.Count);
    }

    [Fact]
    public void GetIngredientsById_ShouldReturnIngredientsForValidId()
    {
        var ingredientId = 1;

        var result = _ingredientRepository.GetIngredientById(ingredientId);

        Assert.NotNull(result);
        Assert.Equal(ingredientId, result.Id);
    }

    [Fact]
    public void GetIngredientById_ShouldThrowExceptionForInvalidId()
    {
        var invalidIngredientId = int.MaxValue;

        Assert.Throws<IngredientRepositoryException>(() => _ingredientRepository.GetIngredientById(invalidIngredientId));
    }

    [Fact]
    public void UpdateIngredient_ShouldUpdateExistingIngredient()
    {
        var existingIngredientId = 1;
        var updatedIngredient = new DomainIngredient(existingIngredientId, "UpdatedIngredient", 3m, "UpdatedBrand", "UpdatedImg");

        _ingredientRepository.UpdateIngredient(updatedIngredient);

        var result = _ingredientRepository.GetIngredientById(existingIngredientId);
        Assert.NotNull(result);
        Assert.Equal(updatedIngredient.Name, result.Name);
        Assert.Equal(updatedIngredient.Price, result.Price);
        Assert.Equal(updatedIngredient.Brand, result.Brand);
        Assert.Equal(updatedIngredient.Img, result.Img);
    }

    [Fact]
    public void UpdateIngredient_ShouldThrowExceptionForNonExistingIngredient()
    {
        var nonExistingIngredient = new DomainIngredient(999, "NonExistingIngredient", 1m, "NonExistingBrand", "NonExistingImg");

        Assert.Throws<IngredientRepositoryException>(() => _ingredientRepository.UpdateIngredient(nonExistingIngredient));
    }

    [Fact]
    public void CreateIngredient_ShouldThrowException_WhenIngredientAlreadyExists()
    {
        var existingIngredientId = 1;
        var duplicateIngredient = new DomainIngredient(existingIngredientId, "DuplicateIngredient", 1m, "DuplicateBrand", "DuplicateImg");

        Assert.Throws<IngredientRepositoryException>(() => _ingredientRepository.CreateIngredient(duplicateIngredient));
    }

    [Fact]
    public void CreateIngredient_ShouldCreateIngredient()
    {
        var newIngredient = new DomainIngredient(11, "NewIngredient", 2m, "NewBrand", "NewImg");

        _ingredientRepository.CreateIngredient(newIngredient);

        var createdIngredient = _ingredientRepository.GetIngredientById(newIngredient.Id);
        Assert.NotNull(createdIngredient);
        Assert.Equal(newIngredient.Name, createdIngredient.Name);
        Assert.Equal(newIngredient.Price, createdIngredient.Price);
        Assert.Equal(newIngredient.Brand, createdIngredient.Brand);
        Assert.Equal(newIngredient.Img, createdIngredient.Img);
    }
}
