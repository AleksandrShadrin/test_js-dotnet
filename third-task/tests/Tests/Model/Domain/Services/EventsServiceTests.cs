using FluentAssertions;
using Model.Domain;
using Model.Domain.Requests;

namespace Tests.Model.Domain.Services;

public class EventsServiceTests
{
    private readonly EventsService _eventsService;

    public EventsServiceTests()
    {
        _eventsService = new();
    }

    [Fact]
    public void ScheduleEvent_ShouldScheduleCorrectEvent()
    {
        // ARRANGE
        var description = new string('1', EventConsts.MinimumDescriptionLength);
        var scheduleAt = DateTime.UtcNow.AddDays(1);

        var request = new ScheduleEventRequest(scheduleAt, description, 0, 1);

        // ACT
        var @event = _eventsService.ScheduleEvent(request);

        // ASSERT
        @event.Should()
            .Match<Event>(e => e.StartAt == scheduleAt
                && e.Description == description
                && e.MinimumMembersCount == 1
                && e.MembersCount == 0);
    }

    [Fact]
    public void ScheduleEvent_ShouldThrowException_WhenStartAtInPast()
    {
        // ARRANGE
        var description = new string('1', EventConsts.MinimumDescriptionLength);
        var scheduleAt = DateTime.UtcNow.AddDays(-1);

        var request = new ScheduleEventRequest(scheduleAt, description, 0, 1);

        // ACT
        var act = () => _eventsService.ScheduleEvent(request);

        // ASSERT
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdateEvent_ShouldCorrectlyUpdateEvent()
    {
        // ARRANGE
        var description = new string('1', EventConsts.MinimumDescriptionLength);
        var newDescription = new string('2', EventConsts.MinimumDescriptionLength);

        var startAt = new DateTime(2023, 12, 09);
        var newStartAt = DateTime.UtcNow.AddDays(1);

        var @event = new Event(startAt, description, 0, 1);

        var request = new UpdateEventRequest(@event, newStartAt, newDescription, 1, 2);

        // ACT
        _eventsService.UpdateEvent(request);

        // ASSERT
        @event.Should()
            .Match<Event>(e => e.StartAt == newStartAt
                && e.Description == newDescription
                && e.MinimumMembersCount == 2
                && e.MembersCount == 1);
    }
}