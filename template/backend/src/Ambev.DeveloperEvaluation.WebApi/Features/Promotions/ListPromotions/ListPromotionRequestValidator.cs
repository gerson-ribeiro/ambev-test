using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.ListPromotions;

public class ListPromotionRequestValidator : AbstractValidator<ListPromotionRequest>
{
    public ListPromotionRequestValidator()
    {
        RuleFor(request => request.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");

        RuleFor(request => request.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0.");
    }
}
