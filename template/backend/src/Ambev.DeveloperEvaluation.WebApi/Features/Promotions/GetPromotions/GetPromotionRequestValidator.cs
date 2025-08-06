using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.GetPromotions;

public class GetPromotionRequestValidator : AbstractValidator<GetPromotionRequest>
{
    public GetPromotionRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }
}
