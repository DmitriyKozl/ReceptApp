namespace VideoplayerProject.Tests.DomainLayerTests.Models
{
    public class IngredientTests
    {

        // TESTS FOR OBJECT INITIALIZATION
        // ID
        [Theory]
        [InlineData(-32, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(32, true)]
        public void IngredientShouldHavePositiveId(int id, bool expectedResult)
        {

            // In the 2 cases, Id's are not positive, so an exception should be thrown            
            if (!expectedResult)
            {
                Assert.Throws<IngredientException>(() => new Ingredient(id, "TestName", 2.0m, "TestBrand", "TestImg"));
            }

            // The last two cases, the Id's are positive, so the object should be created (not null)
            else
            {
                Ingredient sut = new(id, "TestName", 2.0m, "TestBrand", "TestImg");
                Assert.Equal(id, sut.Id);
            }
        }

        //NAME
        [Theory]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData("Soup", true)]
        [InlineData("   Soup", true)]
        [InlineData("Soup       ", true)]
        [InlineData("   Soup     ", true)]
        public void IngredientShouldHaveName(string name, bool expectedResult)
        {
            // In the first 2 cases, the Name is either null, empty or whitespace
            // --> ingredient should not be created (== false)            
            if (!expectedResult)
            {
                Assert.Throws<IngredientException>(() => new Ingredient(2, name, 2.0m, "TestBrand","TestImg"));
            }

            // In the last 3 cases, the Name is filled in (with or without whitespace shouldn't matter)
            // --> ingredient should be created (== true)
            else
            {
                Ingredient sut = new(2, name, 2.0m, "TestBrand","TestImg");
                Assert.Equal(name.Trim(), sut.Name);
            }
        }

        //PRICE
        [Theory]
        [InlineData(-2.0, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        public void IngredientShouldHavePrice(decimal price, bool expectedResult)
        {
            // In the first 2 cases, the Name is either null, empty or whitespace
            // --> ingredient should not be created (== false)            
            if (!expectedResult)
            {
                Assert.Throws<IngredientException>(() => new Ingredient(2, "TestName", price, "TestBrand", "TestImg"));
            }

            // In the last 3 cases, the Name is filled in (with or without whitespace shouldn't matter)
            // --> ingredient should be created (== true)
            else
            {
                Ingredient sut = new(2, "TestName", price, "TestBrand", "TestImg");
                Assert.Equal(sut.Price, price);
            }
        }

        //BRAND
        [Theory]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData("Soubry", true)]
        [InlineData("   Soubry", true)]
        [InlineData("Soubry       ", true)]
        [InlineData("   Soubry     ", true)]
        public void IngredientShouldHaveBrand(string brand, bool expectedResult)
        {
            // In the first 2 cases, the Name is either null, empty or whitespace
            // --> ingredient should not be created (== false)            
            if (!expectedResult)
            {
                Assert.Throws<IngredientException>(() => new Ingredient(2, "TestName", 2.0m, brand, "TestImg"));
            }

            // In the last 3 cases, the Name is filled in (with or without whitespace shouldn't matter)
            // --> ingredient should be created (== true)
            else
            {
                Ingredient sut = new(2, "TestName", 2.0m, brand, "TestImg");
                Assert.Equal(brand.Trim(), sut.Brand);
            }
        }
    }
}