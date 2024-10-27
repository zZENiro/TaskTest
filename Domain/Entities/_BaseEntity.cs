namespace Domain.Entities;

public abstract class BaseEntity
{
    public abstract Guid Id { get; set; }

    /// <summary>
    /// Время создания записи.
    /// </summary>
    public abstract DateTime Created { get; }
    
    /// <summary>
    /// Время обновления записи.
    /// </summary>
    public abstract DateTime? Updated { get; set; }
}