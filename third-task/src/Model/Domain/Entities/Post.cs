using Model.Domain.Entities;

namespace Model.Domain;

public class Post : EntityWithCreationTime<int>
{
    public Author Author { get; init; } = default!;
    public string Content { get; private set; } = default!;
    public string Preview { get; private set; } = default!;
    public ICollection<Comment> Comments { get; set; } = default!;

    public Post(
        Author author,
        DateTime createdAt,
        string content,
        string preview,
        ICollection<Comment> comments)
        : base(createdAt)
    {
        ValidateAndThrow(author, content, preview);

        Author = author;
        Content = content;
        Preview = preview;
        Comments = comments;
    }

    public Post(
        Author author,
        DateTime createdAt,
        string content,
        string preview)
        : this(author, createdAt, content, preview, new List<Comment>())
    {
    }

    public void UpdateContent(string content)
    {
        ValidateContent(content);
        Content = content;
    }

    public void UpdatePreview(string preview)
    {
        ValidateContent(preview);
        Preview = preview;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    private static void ValidateAndThrow(Author author, string content, string preview)
    {
        ArgumentNullException.ThrowIfNull(author);

        ValidateContent(content);
        ValidatePreview(preview);
    }

    private static void ValidateContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content)
                    || content.Length < PostConsts.MinimumContentLength
                    || content.Length > PostConsts.MaximumContentLength)
            throw new ArgumentOutOfRangeException("Content length is not valid");
    }

    private static void ValidatePreview(string preview)
    {
        if(string.IsNullOrWhiteSpace(preview)
                    || preview.Length < PostConsts.MinimumPreviewLength
                    || preview.Length > PostConsts.MaximumPreviewLength)
            throw new ArgumentOutOfRangeException("Preview length is not valid");
    }
}
