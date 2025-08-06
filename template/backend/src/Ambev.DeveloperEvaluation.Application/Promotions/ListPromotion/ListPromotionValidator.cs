using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Promotions.ListPromotion;

public class ListPromotionValidator : AbstractValidator<ListPromotionQuery>
{
    public ListPromotionValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page must be greater than or equal to 1.");
        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize must be greater than or equal to 1.");
    }
}
