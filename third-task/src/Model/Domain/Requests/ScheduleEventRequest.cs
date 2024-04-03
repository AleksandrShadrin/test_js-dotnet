namespace Model.Domain.Requests;

public record ScheduleEventRequest(DateTime EventStartAt, string Description, int MembersCount, int MinimumMembersCount);