namespace Domain.Entities;

public class BodyType : BaseEntity
{
    public override Guid Id { get; set; }
    
    public override DateTime Created { get; } = DateTime.Now;
    
    public override DateTime? Updated { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}