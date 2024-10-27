namespace Domain.Entities;

public class Car : BaseEntity
{
    public override Guid Id { get; set; }
    
    public override DateTime Created { get; } = DateTime.Now;
    
    public override DateTime? Updated { get; set; }

    /// <summary>
    /// Модель.
    /// </summary>
    public string Model { get; set; } = string.Empty;
    
    /// <summary>
    /// Число сидений в салоне.
    /// </summary>
    public byte SeatsCount { get; set; }
    
    /// <summary>
    /// Url сайта официального дилера.
    /// </summary>
    public string? DealerSiteUrl { get; set; }
    
    /// <summary>
    /// Тип кузова. Ид.
    /// </summary>
    public Guid BodyTypeId { get; set; }
    
    /// <summary>
    /// Тип кузова.
    /// </summary>
    public BodyType? BodyType { get; set; }
    
    /// <summary>
    /// Бренд. Ид.
    /// </summary>
    public Guid BrandId { get; set; }
    
    /// <summary>
    /// Бренд.
    /// </summary>
    public Brand? Brand { get; set; }
}