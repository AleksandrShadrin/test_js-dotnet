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
}