namespace VideoplayerProject.Tests.DomainLayerTests.Models
{
    public class RecipeTests
    {
        // TESTS FOR OBJECT INITIALIZATION
        // ID
        [Theory]
        [InlineData(-32, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(32, true)]
        public void RecipeShouldHavePositiveId(int id, bool expectedResult)
        {
            Recipe sut = new Recipe("TestNaam", 4, "url", new TimeSpan(0, 30, 0));
            // In the 2 cases, Id's are not positive, so an exception should be thrown            
            if (!expectedResult)
            {
                Assert.Throws<RecipeException>(() => sut.Id = id);
            }

            // The last two cases, the Id's are positive, so the object should be created (not null)
            else
            {
                sut.Id = id;
                Assert.Equal(sut.Id, id);
            }
        }

        //NAME
        [Theory]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData("Tomato soup", true)]
        [InlineData("   Tomato soup", true)]
        [InlineData("Tomato soup       ", true)]
        [InlineData("   Tomato soup     ", true)]
        public void RecipeShouldHaveName(string name, bool expectedResult)
        {
            // In the first 2 cases, the Name is either null, empty or whitespace
            // --> ingredient should not be created (== false)            
            if (!expectedResult)
            {
                Assert.Throws<RecipeException>(() => new Recipe(name, 4, "url", new TimeSpan(0, 30, 0)));
            }

            // In the last 3 cases, the Name is filled in (with or without whitespace shouldn't matter)
            // --> ingredient should be created (== true)
            else
            {
                Recipe sut = new Recipe(name, 4, "url", new TimeSpan(0, 30, 0));
                Assert.Equal(name, sut.Name);
            }
        }

        //SERVINGS
        [Theory]
        [InlineData(-5, false)]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        public void RecipeShouldHavePositiveNumberOfServings(int servings, bool expectedResult)
        {
            // In the first 2 cases, the Name is either null, empty or whitespace
            // --> ingredient should not be created (== false)            
            if (!expectedResult)
            {
                Assert.Throws<RecipeException>(() => new Recipe("TestName", servings, "url", new TimeSpan(0, 30, 0)));
            }

            // In the last 3 cases, the Name is filled in (with or without whitespace shouldn't matter)
            // --> ingredient should be created (== true)
            else
            {
                Recipe sut = new Recipe("TestName", servings, "url", new TimeSpan(0, 30, 0));
                Assert.Equal(sut.Servings, servings);
            }
        }

        //VIDEOLINK
        [Theory]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData("Valid url", true)]
        [InlineData("   Valid url", true)]
        [InlineData("Valid url       ", true)]
        [InlineData("   Valid url     ", true)]
        public void RecipeShouldHaveUrl(string url, bool expectedResult)
        {
            // In the first 2 cases, the Name is either null, empty or whitespace
            // --> ingredient should not be created (== false)            
            if (!expectedResult)
            {
                Assert.Throws<RecipeException>(() => new Recipe("TestName", 4, url, new TimeSpan(0, 30, 0)));
            }

            // In the last 3 cases, the Name is filled in (with or without whitespace shouldn't matter)
            // --> ingredient should be created (== true)
            else
            {
                Recipe sut = new Recipe("TestName", 4, url, new TimeSpan(0, 30, 0));
                Assert.Equal(url, sut.VideoLink);
            }
        }

        //COOKINGTIME
        [Theory]
        [InlineData(0, 0, -30, false)]
        [InlineData(0, 0, -5, false)]
        [InlineData(0, 0, 0, false)]
        [InlineData(0, 0, 30, true)]
        [InlineData(0, 1, 0, true)]
        public void RecipeShouldHavePositiveCookingTIme(int hours, int minutes, int seconds, bool expectedResult)
        {

            TimeSpan ts = new TimeSpan(hours, minutes, seconds);

            // In the 2 cases, Id's are not positive, so an exception should be thrown            
            if (!expectedResult)
            {
                Assert.Throws<RecipeException>(() => new Recipe("TestName", 4, "TestUrl", ts));
            }

            // The last two cases, the Id's are positive, so the object should be created (not null)
            else
            {
                Recipe sut = new Recipe("TestName", 4, "TestUrl", ts);
                Assert.Equal(ts, sut.CookingTime);
            }
        }

        //TESTS FOR METHODS
        // AddIngredientWithTimestamp
        [Fact]
        public void RecipeShouldBeAbleToAddNewIngredientWithTimestamp()
        {
            // Arrange
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "Soubry", "TestImg");
            Timestamp timestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);

            // Act
            recipe.AddIngredientWithTimeStampToRecipe(ingredient, timestamp);

            // Assert
            bool result = recipe.IngredientToTimestamp.TryGetValue(ingredient, out List<Timestamp> timestamps);

            if (result && timestamps.Contains(timestamp))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            Assert.True(result);
        }

        [Fact]
        public void RecipeShouldBeAbleToAddSecondTimestampForAlreadyUsedIngredient()
        {
            // Arrange
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "Soubry", "TestImg");
            Timestamp existingTimestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);
            recipe.AddIngredientWithTimeStampToRecipe(ingredient, existingTimestamp);


            // Act            
            Timestamp newTimestamp = new(new TimeSpan(0, 1, 30), new TimeSpan(0, 1, 40), ingredient.Id);
            recipe.AddIngredientWithTimeStampToRecipe(ingredient, newTimestamp);

            // Assert
            bool result = recipe.IngredientToTimestamp.TryGetValue(ingredient, out List<Timestamp> timestamps);

            if (result && timestamps.Contains(existingTimestamp) && timestamps.Contains(newTimestamp))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            Assert.True(result);
        }

        [Fact]
        public void RecipeShouldNotBeAbleToAddIngredientToAlreadyUsedStarttime()
        {
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "soubry", "TestImg");
            Timestamp existingTimestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);
            Timestamp newTimestampWithSameStarttime = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 30), ingredient.Id);

            // Add the ingredient with timestamp
            recipe.AddIngredientWithTimeStampToRecipe(ingredient, existingTimestamp);

            // Adding anything to a timestamp with the same starttime as an existing timestamp should throw an error
            Assert.Throws<RecipeException>(() => recipe.AddIngredientWithTimeStampToRecipe(ingredient, newTimestampWithSameStarttime));
        }

        [Fact]
        public void RecipeShouldBeAbleToNewIngredientWithTimestamp()
        {
            // Arrange
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "Soubry", "TestImg");
            Timestamp timestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);
            recipe.AddIngredientWithTimeStampToRecipe(ingredient, timestamp);

            // Assert
            bool result = recipe.IngredientToTimestamp.TryGetValue(ingredient, out List<Timestamp> timestamps);

            if (result && timestamps.Contains(timestamp) && timestamps.Count == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            Assert.True(result);
        }

        [Fact]
        public void RecipeShouldBeAbleToRemoveIngredient()
        {
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "Soubry", "TestImg");
            Timestamp timestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);
            recipe.AddIngredientWithTimeStampToRecipe(ingredient, timestamp);

            recipe.RemoveIngredient(ingredient);

            Assert.DoesNotContain(ingredient, recipe.IngredientToTimestamp.Keys);
        }

        [Fact]
        public void RecipeShouldThrowExceptionWhenNonExistentIngredientIsRemoved()
        {
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "Soubry", "TestImg");
            Timestamp timestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);

            Assert.Throws<RecipeException>(() => recipe.RemoveIngredient(ingredient));
        }

        [Fact]
        public void RecipeShouldBeAbleToRemoveTimestampForGivenIngredient()
        {
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "Soubry", "TestImg");
            Timestamp timestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);

            recipe.AddIngredientWithTimeStampToRecipe(ingredient, timestamp);

            //recipe.RemoveTimestampForIngredient(ingredient, timestamp);

            // The timestamp should no longer be used for the given ingredient
            // It should be true that the timestamp is no longer in the list
            Assert.True(!recipe.IngredientToTimestamp[ingredient].Contains(timestamp));
        }

        [Fact]
        public void RecipeShouldThrowExceptionWhenNonExistentTimestampIsRemoved()
        {
            Recipe recipe = new("Pasta pesto", 4, "TestUrl", new TimeSpan(0, 0, 30));
            Ingredient ingredient = new(1, "spaghetti", 2.0m, "Soubry", "TestImg");
            Timestamp timestamp = new(new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 25), ingredient.Id);

            //Assert.Throws<RecipeException>(() => recipe.RemoveTimestampForIngredient(ingredient, timestamp));
        }
    }
}
