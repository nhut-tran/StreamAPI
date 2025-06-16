using StreamAPI.Domain;

namespace StreamAPI.Tests.Domain;

public class MovieTest
{
    public MovieTest()
    {
        Console.WriteLine("run-----------------");
    }
    [Fact]
    public void MovieShould_Created()
    {
        //arrange
        var name = "ok";
        var categoryId = 1;
        var seasonId = 1;
        //act
        var movie = Movie.Create(name, categoryId, seasonId);
        ////assert
        Assert.Equal(name, movie.Name);
        Assert.Equal(categoryId, movie.CategoryId);
        Assert.Equal(seasonId, movie.SeasonId);
    }

    [Theory]
    [InlineData(1, 60)]
    [InlineData(2, 120)]
    [InlineData(2.5, 150)]
    public void CalculateDuration_Test(float hour, float expectedDuration)
    {
        //arrange
        var movie = new Movie("ok", 1, 1);
        //act
        var minutes = movie.CalculateDurationInMinutes(hour);
        //assert
        Assert.Equal(expectedDuration, minutes);
    }
}