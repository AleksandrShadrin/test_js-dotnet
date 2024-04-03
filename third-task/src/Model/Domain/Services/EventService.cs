using Model.Domain.Requests;

namespace Model.Domain;

public interface IEventService
{
    Event ScheduleEvent(ScheduleEventRequest request);
    void UpdateEvent(UpdateEventRequest request);
}

public class EventService : IEventService
{
    public Event ScheduleEvent(ScheduleEventRequest request)
    {
        if(request.EventStartAt < DateTime.UtcNow)
        {
            throw new ArgumentException("Can't schedule event in the past");
        }

        return new Event(
            request.EventStartAt,
            request.Description,
            request.MembersCount,
            request.MinimumMembersCount);
    }

    public void UpdateEvent(UpdateEventRequest request)
    {
        if (!string.IsNullOrWhiteSpace(request.Description))
        {
            request.Event.UpdateDescription(request.Description);
        }

        if (request.MembersCount is not null)
        {
            request.Event.UpdateMembersCount(request.MembersCount.Value);
        }

        if (request.MinimumMembersCount is not null)
        {
            request.Event.UpdateMinimumMembersCount(request.MinimumMembersCount.Value);
        }

        if (request.ScheduleAt is not null)
        {
            request.Event.UpdateStartAt(request.ScheduleAt.Value);
        }
    }
}
