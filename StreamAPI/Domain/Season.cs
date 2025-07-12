namespace StreamAPI.Domain;

public class Season
{
    public int Id { get; private set; }
    public int Number { get; private set; }

    private readonly List<Episode> _episodes = new();
    public IReadOnlyCollection<Episode> Episodes => _episodes.AsReadOnly();

    public int TvShowId { get; private set; }
    public TvShow TvShow { get; private set; }

    internal Season(int number, TvShow tvShow)
    {
        Number = number;
        TvShow = tvShow ?? throw new ArgumentNullException(nameof(tvShow));
    }

    public Episode AddEpisode(int number, string title)
    {
        if (_episodes.Any(e => e.Number == number))
            throw new InvalidOperationException($"Episode {number} already exists in Season {Number}.");

        var episode = new Episode(number, title, this);
        _episodes.Add(episode);
        return episode;
    }
    // For EF
    private Season() {}
}
