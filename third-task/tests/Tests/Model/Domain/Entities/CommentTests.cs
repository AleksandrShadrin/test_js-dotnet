using FluentAssertions;
using Model.Domain;

namespace Tests.Model.Domain.Entities;

public class CommentTests
{
    [Fact]
    public void CreateNewComment_ShouldThrowException_WhenAuthorIsNull()
    {
        // ARRANGE
        Author author = null!;

        // ACT
        var act = () => new Comment(
            author,
            new string('1', CommentConsts.MinimumContentLength),
            DateTime.Now);

        // ASSERT
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(CommentConsts.MinimumContentLength - 1)]
    [InlineData(CommentConsts.MaximumContentLength + 1)]
    public void CreateNewComment_ShouldThrowException_WhenContentLengthIsNotValid(int contentLength)
    {
        // ARRANGE
        Author author = new Author();

        // ACT
        var act = () => new Comment(
            author,
            new string('1', contentLength),
            DateTime.Now);

        // ASSERT
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateNewComment_ShouldWorkCorrectly_WhenAllParametersOk()
    {
        // ARRANGE
        Author author = new Author();

        // ACT
        var act = () => new Comment(
            author,
            new string('1', CommentConsts.MaximumContentLength),
            DateTime.Now);

        // ASSERT
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void UpdateContent_ShouldWorkCorrectly()
    {
        // ARRANGE
        var comment = GetComment();
        var newContent = new string('2', PostConsts.MinimumContentLength);

        // ACT
        comment.UpdateContent(newContent);

        // ASSERT
        comment.Content.Should().Be(newContent);
    }

    [Theory]
    [InlineData(CommentConsts.MinimumContentLength - 1)]
    [InlineData(CommentConsts.MaximumContentLength + 1)]
    public void UpdateContent_ShouldThrowException_WhenContentIsNotValid(int contentLength)
    {
        // ARRANGE
        var comment = GetComment();
        var newContent = new string('2', contentLength);

        // ACT
        var act = () => comment.UpdateContent(newContent);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    public Comment GetComment() 
        => new Comment(new Author(), new string('1', CommentConsts.MinimumContentLength), DateTime.UtcNow);
}
