namespace StreamAPI.Domain;

public class Movie : Media
{
    private Movie(string title) : base(title, Category.Movie) { }

    public static Movie Create(string title) => new Movie(title);

    // For EF Core
    private Movie() : base() { }
}

