using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public int SaleNumber { get; set; }
    public double Total { get; set; }
    public Guid BranchId { get; set; }
    public SaleStatus Status { get; set; }
    public List<UpdateSaleItems> Items { get; set; }
}

public class UpdateSaleItems
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice => Quantity * UnitPrice;
}