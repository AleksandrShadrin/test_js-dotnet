namespace Model.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get => DateTime.UtcNow; }
}