using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public class CreateSaleRequest
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public double Total { get; set; }
    public Guid BranchId { get; set; }
    public SaleStatus Status { get; set; }
    public List<CreateSaleItemRequest> Items { get; set; }
}


public class CreateSaleItemRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice => Quantity * UnitPrice;
}