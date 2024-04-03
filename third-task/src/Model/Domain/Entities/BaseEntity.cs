namespace Model.Domain;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
}
