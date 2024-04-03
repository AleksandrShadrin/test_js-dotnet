using FluentAssertions;
using Model.Domain;

namespace Tests.Model.Domain.Entities;

public class EventTests
{
    [Theory]
    [InlineData(EventConsts.MinimumDescriptionLength - 1)]
    [InlineData(EventConsts.MaximumDescriptionLength + 1)]
    public void CreateNewEvent_ShouldThrowException_WhenDescriptionNotInRange(int descriptionLength)
    {
        // ARRANGE
        var description = new string('1', descriptionLength);

        // ACT
        var act = () => new Event(DateTime.Now, description, 1, 1);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void CreateNewEvent_ShouldThrowException_WhenMinimumNumberOfMembersLessOrEqualZero(int minimumMembersCount)
    {
        // ARRANGE
        var description = new string('1', EventConsts.MinimumDescriptionLength);

        // ACT
        var act = () => new Event(DateTime.Now, description, 1, minimumMembersCount);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CreateNewEvent_ShouldThrowException_WhenNumberOfMembersLessThanZero()
    {
        // ARRANGE
        var description = new string('1', EventConsts.MinimumDescriptionLength);

        // ACT
        var act = () => new Event(DateTime.Now, description, -1, 1);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CreateNewEvent_ShouldWorkCorrectly_WhenAllParametersOk()
    {
        // ARRANGE
        var description = new string('1', EventConsts.MinimumDescriptionLength);

        // ACT
        var act = () => new Event(DateTime.Now, description, 0, 1);

        // ASSERT
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void UpdateDescription_ShouldWorkCorrectly()
    {
        // ARRANGE
        var @event = GetEvent();
        var newDescription = new string('2', EventConsts.MinimumDescriptionLength);
        
        // ACT
        @event.UpdateDescription(newDescription);

        // ASSERT
        @event.Description.Should().Be(newDescription);
    }

    [Theory]
    [InlineData(EventConsts.MinimumDescriptionLength - 1)]
    [InlineData(EventConsts.MaximumDescriptionLength + 1)]
    public void UpdateDescription_ShouldThrowException_WhenDescriptionIsNotValid(int descriptionLength)
    {
        // ARRANGE
        var @event = GetEvent();
        var newDescription = new string('2', descriptionLength);

        // ACT
        var act = () => @event.UpdateDescription(newDescription);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void UpdateMembersCount_ShouldWorkCorrectly()
    {
        // ARRANGE
        var @event = GetEvent();
        var newMembersCount = 3;

        // ACT
        @event.UpdateMembersCount(newMembersCount);

        // ASSERT
        @event.MembersCount.Should().Be(newMembersCount);
    }

    [Fact]
    public void UpdateMembersCount_ShouldThrowException_WhenMembersCountLessThanZero()
    {
        // ARRANGE
        var @event = GetEvent();
        var newMembersCount = -1;

        // ACT
        var act = () => @event.UpdateMembersCount(newMembersCount);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void UpdateMinimumMembersCount_ShouldWorkCorrectly()
    {
        // ARRANGE
        var @event = GetEvent();
        var newMinimumMembersCount = 3;

        // ACT
        @event.UpdateMinimumMembersCount(newMinimumMembersCount);

        // ASSERT
        @event.MinimumMembersCount.Should().Be(newMinimumMembersCount);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void UpdateMembersCount_ShouldThrowException_WhenMembersCountLessOrEqualZero(int minimumMembersCount)
    {
        // ARRANGE
        var @event = GetEvent();

        // ACT
        var act = () => @event.UpdateMinimumMembersCount(minimumMembersCount);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    private Event GetEvent()
        => new Event(DateTime.Now, new string('1', EventConsts.MinimumDescriptionLength), 0, 1);
}