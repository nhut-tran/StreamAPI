namespace StreamAPI.Domain;

public class Movie : EntityWithTimeStamp
{
    private Movie() {}
    public Movie(string title, int releaseYear, string description, Category category, IEnumerable<Genre> genres)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");
        if (releaseYear < 1900  || releaseYear > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException(nameof(releaseYear));
        }
        ArgumentNullException.ThrowIfNull(genres);
        
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Category = category;
        if (category is Category.SingleMovie)
        {
            AddSeason(1);
        }
        foreach (var genre in genres)
        {
            AddGenre(genre);
        }
    }

    public int Id { get; private set; }
    public Guid PublicId { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Description { get; private set; } = null!;
    public Category Category { get; private set; }
    public int ReleaseYear { get; private set; }
    public MovieStatus Status { get; private set; } = MovieStatus.PendingUpload;
    private readonly List<MovieGenre> _genres = new();
    public IReadOnlyCollection<MovieGenre> Genres => _genres.AsReadOnly();
    private readonly List<Season> _seasons = new();
    public IReadOnlyCollection<Season> Seasons => _seasons.AsReadOnly();
    
    public void AddGenre(Genre genre)
    {
        if (_genres.Any(g => g.GenreId == genre.Id)) return;

        _genres.Add(new MovieGenre(this, genre));
    }

    public void RemoveGenre(Genre genre)
    {
        _genres.RemoveAll(g => g.GenreId == genre.Id);
    }
    public Season AddSeason(int number)
    {
        if (_seasons.Any(s => s.Number == number))
            throw new InvalidOperationException($"Season {number} already exists.");
        if (Category is Category.SingleMovie)
        {
            throw new InvalidOperationException($"Single movie not allowed for season");
        }
        var season = new Season(number, this);
        _seasons.Add(season);
        return season;
    }
  
}


