using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSaleResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public GetSaleUserResponse Customer { get; set; }
    public double Total { get; set; }
    public GetSaleBranchResponse Branch { get; set; }
    public Guid BranchId { get; set; }
    public SaleStatus Status { get; set; }
    public List<GetSaleItemResponse> Items { get; set; }
}
public class GetSaleUserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class GetSaleBranchResponse
{
    public Guid Id { get; set; }
    public string BranchIdentifier { get; set; }
    public string BranchNumber { get; set; }
    public string CompanyName { get; set; }
    public string Partner { get; set; }
    public string Address { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
public class GetSaleItemResponse
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Discount { get; set; }
    public double DiscountedPrice { get; set; }
    public double TotalAmount { get; set; }
    public GetSaleItemProductResponse Items { get; set; }
    public SaleItemStatus Status { get; set; } = SaleItemStatus.Created;
}

public class GetSaleItemProductResponse
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string Sku { get; set; }
    public string BarCode { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double OriginalPrice { get; set; }
    public bool Active { get; set; }
    public GetSaleItemCategoryResponse Category { get; set; }
}

public class GetSaleItemCategoryResponse
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string DisplayName { get; set; }
}
