using Ambev.DeveloperEvaluation.Application.Promotions.GetPromotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategory;

public class GetCategoryResult
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string DisplayName { get; set; }

    public List<GetPromotionResult> Promotions { get; set; } = new List<GetPromotionResult>();
}
