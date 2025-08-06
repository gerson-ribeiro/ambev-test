using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductResponse
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public IList<ListProductItemResponse> Items { get; set; } = new List<ListProductItemResponse>();
}

public class ListProductItemResponse
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string Sku { get; set; }
    public string BarCode { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double OriginalPrice { get; set; }
    public bool Active { get; set; }
    public Category Category { get; set; } = new("", "");
    public List<Guid> PromotionIds { get; set; } = new();
    public List<ListProductPromotionResponse> Promotions { get; set; } = new List<ListProductPromotionResponse>();
}

public class ListProductPromotionResponse
{
    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }
}
