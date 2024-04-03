namespace Model.Domain;

public class Event : BaseEntity<int>
{
    public DateTime StartAt { get; private set; }
    public string Description { get; private set; } = default!;
    public int MembersCount { get; private set; }
    public int MinimumMembersCount { get; private set; }

    public Event(
        DateTime startAt,
        string description,
        int membersCount,
        int minimumMembersCount)
    {
        ValidateAndThrow(description, membersCount, minimumMembersCount);

        StartAt = startAt;
        Description = description;
        MembersCount = membersCount;
        MinimumMembersCount = minimumMembersCount;
    }

    public void UpdateDescription(string description)
    {
        ValidateAndThrowDescription(description);
        Description = description;
    }

    public void UpdateStartAt(DateTime startAt)
    {
        ValidateStartAtAndThrow(startAt);
        StartAt = startAt;
    }

    public void UpdateMembersCount(int membersCount)
    {
        ValidateMembersCountAndThrow(membersCount);
        MembersCount = membersCount;
    }

    public void UpdateMinimumMembersCount(int minimumMembersCount)
    {
        ValidateMinimumMembersCountAndThrow(minimumMembersCount);
        MinimumMembersCount = minimumMembersCount;
    }

    public bool IsEventTakePlace()
    {
        return MembersCount >= MinimumMembersCount;
    }

    private void ValidateStartAtAndThrow(DateTime startAt)
    {
        if (startAt < DateTime.UtcNow)
            throw new ArgumentException("Event can be scheduled only in future");
    }

    private void ValidateMinimumMembersCountAndThrow(int minimumMembersCount)
    {
        if (minimumMembersCount < 1)
            throw new ArgumentOutOfRangeException("Minimum members count can't be less than 1", nameof(minimumMembersCount));
    }

    private void ValidateMembersCountAndThrow(int membersCount)
    {
        if (membersCount < 0)
            throw new ArgumentOutOfRangeException("Members count can't be negative", nameof(membersCount));
    }

    private void ValidateAndThrowDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description)
            || description.Length < EventConsts.MinimumDescriptionLength
            || description.Length > EventConsts.MaximumDescriptionLength)
            throw new ArgumentOutOfRangeException($"Description length should more than {EventConsts.MinimumDescriptionLength}" +
                $" and less than {EventConsts.MaximumDescriptionLength}");
    }

    private void ValidateAndThrow(string description, int membersCount, int minimumMembersCount)
    {
        ValidateMembersCountAndThrow(membersCount);
        ValidateMinimumMembersCountAndThrow(minimumMembersCount);
        ValidateAndThrowDescription(description);
    }
}
