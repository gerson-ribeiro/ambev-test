using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Results;

public class ListPromotionResult
{
    public int? CurrentPage { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public int? TotalCount { get; set; } = 0;
    public int? TotalPages { get; set; } = 0;
    public IList<ListPromotionItemResult> Items { get; set; } = new List<ListPromotionItemResult>();
}

public class ListPromotionItemResult
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }
}