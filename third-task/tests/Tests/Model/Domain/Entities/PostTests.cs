using FluentAssertions;
using Model.Domain;

namespace Tests.Model.Domain.Entities;

public class PostTests
{
    [Fact]
    public void CreateNewPost_ShouldThrowException_WhenAuthorIsNull()
    {
        // ARRANGE
        Author author = null!;

        // ACT
        var act = () => new Post(
            author,
            DateTime.Now,
            new string('1', PostConsts.MinimumContentLength),
            new string('1', PostConsts.MinimumPreviewLength));

        // ASSERT
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(PostConsts.MinimumContentLength - 1)]
    [InlineData(PostConsts.MaximumContentLength + 1)]
    public void CreateNewPost_ShouldThrowException_WhenContentLengthIsNotValid(int contentLength)
    {
        // ARRANGE
        Author author = new Author();

        // ACT
        var act = () => new Post(
            author,
            DateTime.Now,
            new string('1', contentLength),
            new string('1', PostConsts.MinimumPreviewLength));

        // ASSERT
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(PostConsts.MinimumPreviewLength - 1)]
    [InlineData(PostConsts.MaximumPreviewLength + 1)]
    public void CreateNewPost_ShouldThrowException_WhenPreviewLengthIsNotValid(int contentLength)
    {
        // ARRANGE
        Author author = new Author();

        // ACT
        var act = () => new Post(
            author,
            DateTime.Now,
            new string('1', PostConsts.MaximumContentLength),
            new string('1', contentLength));

        // ASSERT
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateNewPost_ShouldWorkCorrectly_WhenAllParametersOk()
    {
        // ARRANGE
        Author author = new Author();

        // ACT
        var act = () => new Post(
            author,
            DateTime.Now,
            new string('1', PostConsts.MaximumContentLength),
            new string('1', PostConsts.MaximumPreviewLength));

        // ASSERT
        act.Should().NotThrow<Exception>();
    }
}

