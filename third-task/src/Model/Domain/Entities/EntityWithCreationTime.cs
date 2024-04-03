namespace Model.Domain.Entities;

public class EntityWithCreationTime<T> : BaseEntity<T>
{
    public DateTime CreatedAt { get; private set; }

    protected EntityWithCreationTime(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }

    public int DaysGone(DateTime from)
    {
        return (from - CreatedAt).Days;
    }

    public int DaysGoneFromNow()
    {
        return DaysGone(DateTime.UtcNow);
    }
}