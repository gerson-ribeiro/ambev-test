namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategory;

public class ListCategoryRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Identification { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}
