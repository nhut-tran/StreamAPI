namespace StreamAPI.Domain;

public class TvShow : Media
{
    private readonly List<Season> _seasons = new();
    public IReadOnlyCollection<Season> Seasons => _seasons.AsReadOnly();

    private TvShow(string title) : base(title, Category.TVShow) { }

    public static TvShow Create(string title) => new TvShow(title);

    public Season AddSeason(int number)
    {
        if (_seasons.Any(s => s.Number == number))
            throw new InvalidOperationException($"Season {number} already exists.");
        
        var season = new Season(number, this);
        _seasons.Add(season);
        return season;
    }

    // For EF Core
    private TvShow() : base() { }
}

