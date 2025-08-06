using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSaleRequest
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public double Total { get; set; }
    public Guid BranchId { get; set; }
    public SaleStatus Status { get; set; }
    public List<UpdateSaleItemsRequest> Items { get; set; }
}

public class UpdateSaleItemsRequest
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice => Quantity * UnitPrice;
}
