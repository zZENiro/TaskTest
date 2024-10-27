namespace Application.Models.Requests;

/// <summary>
/// Модель запроса к списку автомобилей.
/// </summary>
public class CarsRequestModel
{
    public PaginationModel Pagination { get; set; } = new PaginationModel
    {
        StartIndex = 0,
        Count = 10
    };
}