using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory;

public class GetCategoryRequestValidator : AbstractValidator<GetCategoryRequest>
{
    public GetCategoryRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category ID is required");
    }
}
