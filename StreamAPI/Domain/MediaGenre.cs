namespace StreamAPI.Domain;

public class MovieGenre
{
    // For EF Core
    private MovieGenre() { }
    public int MovieId { get; private set; }
    public Movie Movie { get; private set; }

    public int GenreId { get; private set; }
    public Genre Genre { get; private set; }

    public DateTime AddedAt { get; private set; }

    internal MovieGenre(Movie movie, Genre genre)
    {
        Movie = movie ?? throw new ArgumentNullException(nameof(movie));
        Genre = genre ?? throw new ArgumentNullException(nameof(genre));
        MovieId = movie.Id;
        GenreId = genre.Id;
        AddedAt = DateTime.UtcNow;
    }

 
}

