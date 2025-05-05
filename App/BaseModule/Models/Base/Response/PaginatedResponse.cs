namespace RecipeApi.BaseModule.Models.Base;

public class PaginatedResponse<T>
{
    public required string Message { get; set; }
    public required IEnumerable<T> Data { get; set; }
    public int Page { get; set; }
    public int TotalPage { get; set; }
    public int TotalCount { get; set; }
}