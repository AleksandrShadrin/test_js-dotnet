namespace Model.Domain;

public record AddCommentRequest(Post Post, Author Author, string Comment);