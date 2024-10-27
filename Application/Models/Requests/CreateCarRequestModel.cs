namespace Application.Models.Requests;

public class CreateCarRequestModel
{
    /// <summary>
    /// Бренд. Идентификатор.
    /// </summary>
    public Guid? BrandId { get; init; } = null!;

    /// <summary>
    /// Название модели.
    /// </summary>
    public string? Model { get; init; } = null!;

    /// <summary>
    /// Тип кузова. Идентификатор.
    /// </summary>
    public Guid? BodyTypeId { get; init; } = null!;

    /// <summary>
    /// Кол-во мест.
    /// </summary>
    public byte? SeatsCount { get; init; } = null!;

    /// <summary>
    /// Сайт дилера.
    /// </summary>
    public string? DealerSiteUrl { get; init; } = null!;
}