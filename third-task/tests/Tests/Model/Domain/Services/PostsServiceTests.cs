using FluentAssertions;
using Model.Common;
using Model.Domain;
using Moq;

namespace Tests.Model.Domain.Services;

public class PostsServiceTests
{
    private readonly Mock<IDateTimeProvider> _dateTimeProviderMock = new();

    private readonly PostsService _postsService;

    public PostsServiceTests()
    {
        _postsService = new(_dateTimeProviderMock.Object);
    }

    [Fact]
    public void CreatePost_ShouldCreateCorrectPost()
    {
        // ARRANGE
        var author = new Author();
        var content = new string('1', PostConsts.MinimumContentLength);
        var preview = new string('1', PostConsts.MinimumPreviewLength);
        var createdAt = new DateTime(2023, 12, 09);

        _dateTimeProviderMock
            .Setup(dp => dp.UtcNow)
            .Returns(createdAt);

        var request = new CreatePostRequest(author, content, preview);

        // ACT
        var post = _postsService.CreatePost(request);

        // ASSERT
        post.Should()
            .Match<Post>(p => p.CreatedAt == createdAt 
                && p.Author == author
                && p.Content == content
                && p.Preview == preview);
    }

    [Fact]
    public void CommentPost_ShouldCorrectlyCommentPost()
    {
        // ARRANGE
        var author = new Author();
        var postContent = new string('1', PostConsts.MinimumContentLength);
        var commentContent = new string('1', CommentConsts.MinimumContentLength);
        var preview = new string('1', PostConsts.MinimumPreviewLength);

        var post = new Post(author, DateTime.Now, postContent, preview);
        var request = new AddCommentRequest(post, author, commentContent);

        // ACT
        _postsService.CommentPost(request);

        // ASSERT
        post
            .Comments.Should()
            .HaveCount(1)
            .And.ContainSingle(c => c.Author == author && c.Content == commentContent);
    }
}
