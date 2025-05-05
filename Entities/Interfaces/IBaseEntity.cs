namespace RecipeApi.Entities;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    DateTime? DeletedAt { get; set; }
}
