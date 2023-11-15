using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Datalayer.Repositories;



namespace VideoplayerProject.Tests.DataLayerTests.Repositories;

public class IngredientRepositoryTests
{
    private readonly RecipeDbContext _context;
    private readonly IngredientRepository _iRepo;

    public IngredientRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<RecipeDbContext>()
            .UseInMemoryDatabase(databaseName: "test_database" + Guid.NewGuid())
            .Options;

        _context = new RecipeDbContext(options);

        // Seed the in-memory database with test data
        _context.Ingredients.AddRange(new List<DataIngredient>
        {
            new DataIngredient {IngredientID = 1,IngredientName = "Filter1", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 2,IngredientName = "Filter2", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 3,IngredientName = "Filter2", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 4,IngredientName = "Filter3", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 5,IngredientName = "Filter3", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 6,IngredientName = "Filter3", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 7,IngredientName = "Test7", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 8,IngredientName = "Test8", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 9,IngredientName = "Test9", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},
            new DataIngredient {IngredientID = 10,IngredientName = "Test10", Brand = "TestBrand", ImageThumbnail = "TestImg", Price = 2m},

        });

        _context.SaveChanges();

        _iRepo = new IngredientRepository(_context);
    }

    [Theory]
    [InlineData("Filter", 6)]
    [InlineData("Filter1", 1)]
    [InlineData("Filter2", 2)]
    [InlineData("Filter3", 3)]
    public void GetIngredients_Returns_MatchingIngredients_When_Found(string filter, int expectedCount)
    {
        var result = _iRepo.GetIngredients(filter);

        Assert.Equal(expectedCount, result.Count);
        Assert.Contains(result, ingredient => ingredient.Name.Contains(filter));
    }

    [Theory]
    [InlineData("NoMatches", true)]
    [InlineData(" ", true)]
    [InlineData("Filter", false)]
    public void GetIngredients_Returns_Exception_When_Not_Found(string filter, bool expectedResult)
    {
        Action act = () => _iRepo.GetIngredients(filter);

        if (expectedResult)
        {
            Assert.Throws<IngredientException>(() => act.Invoke());
        }
        else
        {
            act.Invoke();
        }
    }

    [Theory]
    [InlineData("", 10)]
    public void GetIngredients_Returns_All_When_Filter_Is_Empty(string filter, int expectedCount)
    {
        var result = _iRepo.GetIngredients(filter);

        Assert.Equal(expectedCount, result.Count);
    }
    [Theory]
    [InlineData(1, "Filter1")]
    [InlineData(2, "Filter2")]
    [InlineData(10, "Test10")]
    public void GetIngredientById_Returns_Correct_Ingredient(int id, string expectedName)
    {
        var result = _iRepo.GetIngredientById(id);
        Assert.Equal(expectedName, result.Name);
        Assert.Equal(id, result.Id);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(1, false)]
    [InlineData(11, true)]

    public void GetIngredientById_Returns_Exception_When_Empty_Or_Null(int id, bool expectedResult)
    {
        Action act = () => _iRepo.GetIngredientById(id);
        if (expectedResult)
        {
            Assert.Throws<IngredientException>(() => act.Invoke());
        }
        else
        {
            act.Invoke();
        }
    }
    [Fact]
    public void CreateIngredient_Creates_Ingredient()
    {
        DomainIngredient newIngredient = new DomainIngredient(11, "add", 2m, "brand", "img");

        _iRepo.CreateIngredient(newIngredient);

        var createdIngredient = _iRepo.GetIngredientById(newIngredient.Id);

        Assert.NotNull(createdIngredient);
        Assert.Equal(newIngredient.Name, createdIngredient.Name);
        Assert.Equal(newIngredient.Price, createdIngredient.Price);
        Assert.Equal(newIngredient.Brand, createdIngredient.Brand);
        Assert.Equal(newIngredient.Img, createdIngredient.Img);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void RemoveIngredient_Deletes_Ingredient(int id)
    {
        var initialIngredient = _iRepo.GetIngredientById(id);
        Assert.NotNull(initialIngredient);
        Assert.Equal(id, initialIngredient.Id);

        _iRepo.RemoveIngredient(id);

        Assert.Throws<IngredientException>(() => _iRepo.GetIngredientById(id));

    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(11)]
    public void RemoveIngredient_Throws_Exception_When_Invalid_Id(int id)
    {
        Assert.Throws<IngredientException>(() => _iRepo.RemoveIngredient(id));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void UpdateIngredient_Updates_Ingredient(int id)
    {
        var initialIngredient = _iRepo.GetIngredientById(id);
        var updatedIngredient = _iRepo.GetIngredientById(id);
        updatedIngredient.Name = "Changed";
        updatedIngredient.Price = 3m;
        updatedIngredient.Brand = "Changed";
        updatedIngredient.Img = "Changed";

        Assert.NotNull(initialIngredient);

        Assert.NotEqual(initialIngredient.Name, updatedIngredient.Name);
        Assert.NotEqual(initialIngredient.Price, updatedIngredient.Price);
        Assert.NotEqual(initialIngredient.Brand, updatedIngredient.Brand);
        Assert.NotEqual(initialIngredient.Img, updatedIngredient.Img);
    }

}



