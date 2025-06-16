namespace StreamAPI.Domain;

public class Movie
{
    public Movie()
    {
        
    }

    public Movie(string name, int categoryId, int seasonId)
    {
        Name = name;
        CategoryId = categoryId;
        SeasonId = seasonId;
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int CategoryId { get; private set; }
    public int SeasonId { get; private set; }

    public static Movie Create(string name, int categoryId, int seasonId)
    {
        return new Movie(name, categoryId, seasonId);
    }

    public float CalculateDurationInMinutes(float hour)
    {
        return hour * 60;
    }
}