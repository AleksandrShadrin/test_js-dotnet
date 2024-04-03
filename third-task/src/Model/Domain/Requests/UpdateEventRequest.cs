namespace Model.Domain.Requests;

public record UpdateEventRequest(Event Event, DateTime? ScheduleAt, string? Description, int? MembersCount, int? MinimumMembersCount);