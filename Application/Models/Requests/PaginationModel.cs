namespace Application.Models.Requests;

/// <summary>
/// Модель пагинации.
/// </summary>
public class PaginationModel
{
    /// <summary>
    /// Количество запрашиваемых элементов.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Индекс, с которого начинается выдача контента.
    /// </summary>
    public int StartIndex { get; set; }
}