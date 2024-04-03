using Model.Domain.Entities;

namespace Model.Domain;

public class Comment : EntityWithCreationTime<int>
{
    public Author Author { get; init; } = default!;
    public string Content { get; private set; } = default!;

    public Comment(
        Author author,
        string content,
        DateTime createdAt)
        : base(createdAt)
    {
        ValidateAndThrow(author, content);

        Author = author;
        Content = content;
    }

    public void UpdateContent(string content)
    {
        ValidateContent(content);
        Content = content;
    }

    private static void ValidateAndThrow(Author author, string content)
    {
        ArgumentNullException.ThrowIfNull(author);
        ValidateContent(content);
    }

    private static void ValidateContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content)
                    || content.Length < CommentConsts.MinimumContentLength
                    || content.Length > CommentConsts.MaximumContentLength)
            throw new ArgumentOutOfRangeException("Content length is not valid");
    }
}
