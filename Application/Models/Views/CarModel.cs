namespace Application.Models.Views;

/// <summary>
/// View-модель автомобиля.
/// </summary>
public class CarModel
{
    public Guid Id { get; set; }
    
    public DateTime Created { get; } = DateTime.Now;
    
    public DateTime? Updated { get; set; }

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
    /// Тип кузова.
    /// </summary>
    public string? BodyType { get; set; }
    
    /// <summary>
    /// Бренд.
    /// </summary>
    public string? Brand { get; set; }
}