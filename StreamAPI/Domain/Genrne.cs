namespace StreamAPI.Domain;

public class Genre
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private readonly List<MovieGenre> _movieGenres = new();
    public IReadOnlyCollection<MovieGenre> MovieGenres => _movieGenres.AsReadOnly();

    public Genre(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Genre name is required.");
        Name = name;
    }

    // For EF
    private Genre() { }
}

