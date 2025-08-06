using Ambev.DeveloperEvaluation.WebApi.Features.Promotions.ListPromotions;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

public class ListSaleResponse
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public IList<GetSaleResponse> Items { get; set; } = new List<GetSaleResponse>();
}
