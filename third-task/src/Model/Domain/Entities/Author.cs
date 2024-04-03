namespace Model.Domain;

public class Author : BaseEntity<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
