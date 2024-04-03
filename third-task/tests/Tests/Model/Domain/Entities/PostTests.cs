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

    [Fact]
    public void UpdateContent_ShouldWorkCorrectly()
    {
        // ARRANGE
        var post = GetPost();
        var newContent = new string('2', PostConsts.MinimumContentLength);

        // ACT
        post.UpdateContent(newContent);

        // ASSERT
        post.Content.Should().Be(newContent);
    }

    [Theory]
    [InlineData(PostConsts.MinimumContentLength - 1)]
    [InlineData(PostConsts.MaximumContentLength + 1)]
    public void UpdateContent_ShouldThrowException_WhenContentIsNotValid(int contentLength)
    {
        // ARRANGE
        var post = GetPost();
        var newContent = new string('2', contentLength);

        // ACT
        var act = () => post.UpdateContent(newContent);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void UpdatePreview_ShouldWorkCorrectly()
    {
        // ARRANGE
        var post = GetPost();
        var preview = new string('2', PostConsts.MinimumPreviewLength);

        // ACT
        post.UpdatePreview(preview);

        // ASSERT
        post.Preview.Should().Be(preview);
    }

    [Theory]
    [InlineData(PostConsts.MinimumPreviewLength - 1)]
    [InlineData(PostConsts.MaximumPreviewLength + 1)]
    public void UpdatePreview_ShouldThrowException_WhenPreviewIsNotValid(int previewLength)
    {
        // ARRANGE
        var post = GetPost();
        var preview = new string('2', previewLength);

        // ACT
        var act = () => post.UpdatePreview(preview);

        // ASSERT
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    public Post GetPost()
        => new Post(
            new Author(),
            DateTime.UtcNow,
            new string('1', PostConsts.MaximumContentLength),
            new string('1', PostConsts.MaximumPreviewLength));
}

