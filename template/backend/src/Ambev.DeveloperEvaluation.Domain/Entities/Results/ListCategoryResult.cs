using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Results;

public class ListCategoryResult
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public IList<ListCategoryItemResult> Items { get; set; } = new List<ListCategoryItemResult>();
}
public  class ListCategoryItemResult
{
    public string Id { get; set; }
    public string Identification { get; set; }
    public string DisplayName { get; set; }

    public virtual IList<ListCategoryPromotionResult> Promotions { get; set; } = new List<ListCategoryPromotionResult>();
}

public class ListCategoryPromotionResult
{
    public string Id { get; set; }
    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }
}