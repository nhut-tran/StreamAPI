namespace StreamAPI.Domain;

public class Episode : EntityWithTimeStamp
{
    public int Id { get; private set; }
    public TimeSpan Duration { get; private set; }
    public int Number { get; private set; }
    public string Title { get; private set; }
    public string? PlayBackUrl { get; private set; }
    public VideoUploadStatus UploadStatus { get; private set; } = VideoUploadStatus.PendingUpload;
    public int SeasonId { get; private set; }
    public Season Season { get; private set; }

    internal Episode(int number, string title, TimeSpan duration,  Season season)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");
        if(duration.TotalMinutes < 1)
            throw new ArgumentException("Duration must be greater than 1 minute.");
        Number = number;
        Title = title;
        Duration = duration;
        Season = season ?? throw new ArgumentNullException(nameof(season));
    }
    // For EF core
    private Episode() {}
    
    public void MarkVideoUploaded(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("Invalid video file path.");

        PlayBackUrl = filePath;
        UploadStatus = VideoUploadStatus.Ready;
    }

    public void MarkProcessed(TimeSpan duration)
    {
        Duration = duration;
        UploadStatus = VideoUploadStatus.Processing;
    }
}
