namespace StreamAPI.Domain;

public class MediaGenre
{
    public int MediaId { get; private set; }
    public Media Media { get; private set; }

    public int GenreId { get; private set; }
    public Genre Genre { get; private set; }

    public DateTime AddedAt { get; private set; }

    internal MediaGenre(Media media, Genre genre)
    {
        Media = media ?? throw new ArgumentNullException(nameof(media));
        Genre = genre ?? throw new ArgumentNullException(nameof(genre));
        MediaId = media.Id;
        GenreId = genre.Id;
        AddedAt = DateTime.UtcNow;
    }

    // For EF Core
    private MediaGenre() { }
}

