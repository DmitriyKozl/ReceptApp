namespace VideoplayerProject.Tests.DomainLayerTests.Models
{
    public class TimeStampTests
    {
        // TESTS FOR OBJECT INITIALIZATION
        // ID
        [Theory]
        [InlineData(-32, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(32, true)]
        public void TimestampShouldHavePositiveIngredientId(int id, bool expectedResult)
        {

            // In the 2 cases, Id's are not positive, so an exception should be thrown            
            if (!expectedResult)
            {
                Assert.Throws<TimestampException>(() => new Timestamp(new TimeSpan(0, 0, 30), new TimeSpan(0, 0, 45), id));
            }

            // The last two cases, the Id's are positive, so the object should be created (not null)
            else
            {
                Timestamp sut = new Timestamp(new TimeSpan(0, 0, 30), new TimeSpan(0, 0, 45), id);
                Assert.Equal(id, sut.IngredientId);
            }
        }

        //STARTTIME
        [Theory]
        [InlineData(0, 0, -30, false)]
        [InlineData(0, 0, 0, false)]
        [InlineData(0, 0, 1, true)]
        [InlineData(0, 0, 30, true)]
        public void TimestampShouldHavePositiveStartTime(int hours, int minutes, int seconds, bool expectedResult)
        {

            TimeSpan ts = new TimeSpan(hours, minutes, seconds);

            // In the 2 cases, Id's are not positive, so an exception should be thrown            
            if (!expectedResult)
            {
                Assert.Throws<TimestampException>(() => new Timestamp(ts, new TimeSpan(0, 0, 45), 5));
            }

            // The last two cases, the Id's are positive, so the object should be created (not null)
            else
            {
                Timestamp sut = new Timestamp(ts, new TimeSpan(0, 0, 45), 5);
                Assert.Equal(ts, sut.StartTime);
            }
        }

        //ENDTIME
        [Theory]
        [InlineData(0, 0, -30, false)]
        [InlineData(0, 0, 0, false)]
        [InlineData(0, 0, 1, false)]
        [InlineData(0, 0, 30, false)]
        [InlineData(0, 1, 0, true)]
        public void TimestampShouldHaveEndTimeAfterStartTime(int hours, int minutes, int seconds, bool expectedResult)
        {

            TimeSpan ts = new TimeSpan(hours, minutes, seconds);

            // In the 2 cases, Id's are not positive, so an exception should be thrown            
            if (!expectedResult)
            {
                Assert.Throws<TimestampException>(() => new Timestamp(new TimeSpan(0, 0, 45), ts, 5));
            }

            // The last two cases, the Id's are positive, so the object should be created (not null)
            else
            {
                Timestamp sut = new Timestamp(new TimeSpan(0, 0, 45), ts, 5);
                Assert.Equal(ts, sut.EndTime);
            }
        }
    }
}
