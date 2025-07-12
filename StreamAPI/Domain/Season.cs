namespace StreamAPI.Domain;

public class Season : EntityWithTimeStamp
{
    public int Id { get; private set; }
    public int Number { get; private set; }

    private readonly List<Episode> _episodes = new();
    public IReadOnlyCollection<Episode> Episodes => _episodes.AsReadOnly();

    public int MovieId { get; private set; }
    public Movie Movie { get; private set; }

    internal Season(int number, Movie movie)
    {
        Number = number;
        Movie = movie ?? throw new ArgumentNullException(nameof(movie));
    }

    public Episode AddEpisode(int number, string title, TimeSpan duration)
    {
        if (_episodes.Any(e => e.Number == number))
            throw new InvalidOperationException($"Episode {number} already exists in Season {Number}.");

        var episode = new Episode(number, title, duration, this);
        _episodes.Add(episode);
        return episode;
    }
    // For EF
    private Season() {}
}
