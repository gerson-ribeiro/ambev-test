namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;


    public string? Identification { get; set; }
    public string? Sku { get; set; }
    public string? BarCode { get; set; }
    public string? ImageURL { get; set; }
    public string? Description { get; set; }
    public bool? Active { get; set; }
}
