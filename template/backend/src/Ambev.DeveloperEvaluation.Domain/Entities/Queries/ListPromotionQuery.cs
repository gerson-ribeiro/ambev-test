using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ambev.DeveloperEvaluation.Domain.Entities.Queries;

public class ListPromotionQuery : IRequest<ListPromotionResult>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Identification { get; set; }
    public double? Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int? MinUnit { get; set; }
    public DateTime? ExpDateMin { get; set; }
    public DateTime? ExpDateMax { get; set; }
}
