using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Results;

public class ListSaleResult
{
    public int? CurrentPage { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public int? TotalCount { get; set; } = 0;
    public int? TotalPages { get; set; } = 0;
    public IList<ListSalesItemResult> Items { get; set; } = new List<ListSalesItemResult>();
}

public class ListSalesItemResult
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public User Customer { get; set; }
    public double Total { get; set; }
    public Branch Branch { get; set; }
    public Guid BranchId { get; set; }
    public SaleStatus Status { get; set; }
    public virtual List<ListSaleItemItemsResult> Items { get; set; }
}
public class ListSaleItemItemsResult
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Discount { get; set; }
    public double DiscountedPrice { get; set; }
    public double TotalAmount { get; set; }
    public ListSaleItemItemsProductResult Items { get; set; }
    public SaleItemStatus Status { get; set; } = SaleItemStatus.Created;
}

public class ListSaleItemItemsProductResult
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string Sku { get; set; }
    public string BarCode { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double OriginalPrice { get; set; }
    public bool Active { get; set; }
    public ListSaleItemItemsProductCategoryResult Category { get; set; }
}

public class ListSaleItemItemsProductCategoryResult
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string DisplayName { get; set; }
}