using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Queries;

public class ListProductQuery : IRequest<ListProductResult>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;


    public string? Identification { get; set; }
    public string? Sku { get; set; }
    public string? BarCode { get; set; }
    public string? ImageURL { get; set; }
    public string? Description { get; set; }
    public bool? Active { get; set; }

}
