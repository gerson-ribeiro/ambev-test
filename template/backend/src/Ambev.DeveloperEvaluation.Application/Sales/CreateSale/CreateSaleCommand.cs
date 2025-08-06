using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public double Total { get; set; }
    public Guid BranchId { get; set; }
    public SaleStatus Status { get; set; }
    public List<CreateSaleItemCommand> Items { get; set; }

    public CreateSaleCommand(int saleNumber, DateTime date, Guid customerId, double total, Guid branchId, SaleStatus status, List<CreateSaleItemCommand> items)
    {
        SaleNumber = saleNumber;
        Date = date;
        CustomerId = customerId;
        Total = total;
        BranchId = branchId;
        Status = status;
        Items = items;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }
}

public class CreateSaleItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice => Quantity * UnitPrice;
}
