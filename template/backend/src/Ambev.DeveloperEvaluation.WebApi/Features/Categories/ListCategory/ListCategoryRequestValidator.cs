using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategory;

public class ListCategoryRequestValidator : AbstractValidator<ListCategoryRequest>
{
    public ListCategoryRequestValidator()
    {
        RuleFor(request => request.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");

        RuleFor(request => request.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0.");
    }
}
