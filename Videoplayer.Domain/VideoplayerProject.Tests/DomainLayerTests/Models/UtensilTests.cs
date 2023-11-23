namespace VideoplayerProject.Tests.DomainLayerTests.Models
{
    public class UtensilTests
    {
        // TESTS FOR OBJECT INITIALIZATION
        // ID
        [Theory]
        [InlineData(-32, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(32, true)]
        public void UtensilShouldHavePositiveId(int id, bool expectedResult)
        {

            // In the 2 cases, Id's are not positive, so an exception should be thrown            
            if (!expectedResult)
            {
                Assert.Throws<UtensilException>(() => new Utensil(id,"TestName", "ImgUrl"));
            }

            // The last two cases, the Id's are positive, so the object should be created (not null)
            else
            {
                Utensil sut = new Utensil(id,"TestName", "ImgUrl");
                Assert.Equal(sut.Id, id);
            }
        }

        //NAME
        [Theory]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData("Fork", true)]
        [InlineData("   Fork", true)]
        [InlineData("Fork       ", true)]
        [InlineData("   Fork     ", true)]
        public void UtensilShouldHaveName(string name, bool expectedResult)
        {
            // In the first 2 cases, the Name is either null, empty or whitespace
            // --> ingredient should not be created (== false)            
            if (!expectedResult)
            {
                Assert.Throws<UtensilException>(() => new Utensil(name,"ImgUrl"));
            }

            // In the last 3 cases, the Name is filled in (with or without whitespace shouldn't matter)
            // --> ingredient should be created (== true)
            else
            {
                Utensil sut = new Utensil(name, "ImgUrl");
                Assert.Equal(name, sut.Name);
            }
        }
    }
}
