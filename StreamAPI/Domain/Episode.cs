namespace StreamAPI.Domain;

public class Episode
{
    public int Id { get; private set; }
    public int Number { get; private set; }
    public string Title { get; private set; }

    public int SeasonId { get; private set; }
    public Season Season { get; private set; }

    internal Episode(int number, string title, Season season)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");

        Number = number;
        Title = title;
        Season = season ?? throw new ArgumentNullException(nameof(season));
    }
    // For EF core
    private Episode() {}
}
