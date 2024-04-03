namespace Model.Domain;

public record CreatePostRequest(Author Author, string Content, string Preview);