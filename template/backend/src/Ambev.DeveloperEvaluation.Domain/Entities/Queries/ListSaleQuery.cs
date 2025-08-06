using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Queries;

public class ListSaleQuery : IRequest<ListSaleResult>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public int SaleNumber { get; set; } = 0;
    public DateTime Date { get; set; } = DateTime.MinValue;
    public User Customer { get; set; } = null!;
    public double Total { get; set; } = 0.0;
    public SaleStatus Status { get; set; } = SaleStatus.Created;
}
