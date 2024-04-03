using Model.Common;

namespace Model.Domain;

public interface IPostsService
{
    Post CreatePost(CreatePostRequest request);
    void CommentPost(AddCommentRequest request);
}

public class PostsService : IPostsService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostsService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Post CreatePost(CreatePostRequest request)
    {
        return new Post(request.Author, _dateTimeProvider.UtcNow, request.Content, request.Preview);
    }

    public void CommentPost(AddCommentRequest request)
    {
        var comment = new Comment(request.Author, request.Comment, _dateTimeProvider.UtcNow);
        request.Post.AddComment(comment);
    }
}