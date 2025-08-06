using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategory;

public  class GetCategoryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Category ID cannot be an empty GUID.");
    }
}
