namespace StreamAPI.Domain;

public class EntityWithTimeStamp
{
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }
    public void SetCreatedAt() => CreatedAt = DateTimeOffset.UtcNow;
    public void SetUpdatedAt() => CreatedAt = DateTimeOffset.UtcNow;
}