using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Discount { get; set; }
    public double DiscountedPrice { get; set; }
    public double TotalAmount { get; set; }
    public Sale Sale { get; set; }
    public Product Items { get; set; }
    public SaleItemStatus Status { get; set; } = SaleItemStatus.Created;
    public SaleItem()
    {

    }
    public SaleItem(Guid saleId, Guid productId, int quantity, double unitPrice, double discount, double discountedPrice, double totalAmount)
    {
        SaleId = saleId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
        DiscountedPrice = discountedPrice;
        TotalAmount = totalAmount;
    }
}