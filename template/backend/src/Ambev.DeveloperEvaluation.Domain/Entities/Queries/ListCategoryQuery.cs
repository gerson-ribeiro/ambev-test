using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Queries;

public class ListCategoryQuery : IRequest<ListCategoryResult>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Identification { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;

}
