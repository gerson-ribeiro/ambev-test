using Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.ListPromotions;

public class ListPromotionResponse
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public IList<ListPromotionItemResponse> Items { get; set; } = new List<ListPromotionItemResponse>();

}

public class ListPromotionItemResponse
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }

}
