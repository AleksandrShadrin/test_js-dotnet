using FluentAssertions;
using Model.Domain.Entities;

namespace Tests.Model.Domain.Entities;

public class ExtensionsTests
{
    [Fact]
    public void DaysGoneFromNow_ShouldWorkCorrectly()
    {
        // ARRANGE
        var entityWithCreationTime = new TestEntity(DateTime.UtcNow.AddHours(-25));

        // ACT
        var result = entityWithCreationTime.DaysGoneFromNow();

        // ASSERT
        result.Should().Be(1);
    }

    [Fact]
    public void DaysGone_ShouldWorkCorrectly()
    {
        // ARRANGE
        var createdAt = new DateTime(2023, 12, 9);
        var fromDate = new DateTime(2023, 12, 11);

        var entityWithCreationTime = new TestEntity(createdAt);

        // ACT
        var result = entityWithCreationTime.DaysGone(fromDate);

        // ASSERT
        result.Should().Be(2);
    }

    private class TestEntity : EntityWithCreationTime<int>
    {
        public TestEntity(DateTime createdAt)
            : base(createdAt)
        {
        }
    }
}