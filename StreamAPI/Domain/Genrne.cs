namespace StreamAPI.Domain;

public class Genre
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private readonly List<MediaGenre> _mediaGenres = new();
    public IReadOnlyCollection<MediaGenre> MediaGenres => _mediaGenres.AsReadOnly();

    public Genre(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Genre name is required.");
        Name = name;
    }

    // For EF
    private Genre() { }
}

