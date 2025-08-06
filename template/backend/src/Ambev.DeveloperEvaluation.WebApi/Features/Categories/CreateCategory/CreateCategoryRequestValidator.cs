using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.CreateCategory;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(request => request.Identification)
            .NotEmpty()
            .WithMessage("Category identification is required.")
            .Length(3, 100)
            .WithMessage("Category identification must be between 3 and 100 characters long.");

        RuleFor(request => request.DisplayName)
            .NotEmpty()
            .WithMessage("Category description is required.")
            .Length(3, 100)
            .WithMessage("Category identification must be between 3 and 100 characters long.");
    }
}
