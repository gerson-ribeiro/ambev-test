using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
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
            .WithMessage("Category description must be between 3 and 100 characters long.");
    }
}
