using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.CreatePromotions;

public class CreatePromotionRequestValidator : AbstractValidator<CreatePromotionRequest>
{
    public CreatePromotionRequestValidator()
    {
        RuleFor(x => x.Identification)
            .NotEmpty().WithMessage("Identification is required.")
            .Length(1, 50).WithMessage("Identification must be between 1 and 50 characters.");
        RuleFor(x => x.Percent)
            .InclusiveBetween(0, 100).WithMessage("Percent must be between 0 and 100.");
        RuleFor(x => x.MaxUnit)
            .GreaterThanOrEqualTo(0).When(x => x.MaxUnit.HasValue)
            .WithMessage("MaxUnit must be greater than or equal to 0.");
        RuleFor(x => x.MinUnit)
            .GreaterThan(0).WithMessage("MinUnit must be greater than 0.");
        RuleFor(x => x.ExpirationDate)
            .GreaterThan(DateTime.UtcNow).When(x => x.ExpirationDate.HasValue)
            .WithMessage("ExpirationDate must be in the future.");
    }
}
