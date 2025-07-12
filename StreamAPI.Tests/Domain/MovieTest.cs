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

    }

    [Theory]
    [InlineData(1, 60)]
    [InlineData(2, 120)]
    [InlineData(2.5, 150)]
    public void CalculateDuration_Test(float hour, float expectedDuration)
    {
      
    }
}