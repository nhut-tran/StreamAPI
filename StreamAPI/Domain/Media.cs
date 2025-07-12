namespace StreamAPI.Domain;

public abstract class Media
{
    public int Id { get; private set; }
    public Guid PublicId { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public Category Category { get; private set; }

    private readonly List<MediaGenre> _genres = new();
    public IReadOnlyCollection<MediaGenre> Genres => _genres.AsReadOnly();

    protected Media(string title, Category category)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");

        Title = title;
        Category = category;
    }

    public void AddGenre(Genre genre)
    {
        if (_genres.Any(g => g.GenreId == genre.Id)) return;

        _genres.Add(new MediaGenre(this, genre));
    }

    public void RemoveGenre(Genre genre)
    {
        _genres.RemoveAll(g => g.GenreId == genre.Id);
    }

    // For EF Core
    protected Media() { }
}

