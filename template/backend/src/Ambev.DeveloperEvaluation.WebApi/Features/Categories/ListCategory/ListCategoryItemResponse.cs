namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategory;

public class ListCategoryResponse
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }

    public IList<ListSaleItemResponse> Items { get; set; } = new List<ListSaleItemResponse>();

}

public class ListSaleItemResponse
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string DisplayName { get; set; }
}
