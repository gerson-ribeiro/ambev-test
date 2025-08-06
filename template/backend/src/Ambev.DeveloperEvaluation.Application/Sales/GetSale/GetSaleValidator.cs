using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleValidator : AbstractValidator<GetSaleQuery>
{
    public GetSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product ID must not be empty.")
            .Must(id => id != Guid.Empty).WithMessage("Product ID must be a valid GUID.");

    }
}
