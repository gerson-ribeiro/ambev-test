using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

public class ListSaleRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public int SaleNumber { get; set; } = 0;
    public DateTime Date { get; set; } = DateTime.MinValue;
    public User? Customer { get; set; }
    public double Total { get; set; } = 0.0;
    public SaleStatus Status { get; set; } = SaleStatus.Created;
}
