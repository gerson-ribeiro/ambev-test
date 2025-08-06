using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Identification)
            .NotEmpty().WithMessage("Identification is required.")
            .Length(1, 50).WithMessage("Identification must be between 1 and 50 characters.");
        RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("SKU is required.")
            .Length(1, 50).WithMessage("SKU must be between 1 and 50 characters.");
        RuleFor(x => x.BarCode)
            .NotEmpty().WithMessage("BarCode is required.")
            .Length(1, 50).WithMessage("BarCode must be between 1 and 50 characters.");
        RuleFor(x => x.ImageURL)
            .NotEmpty().WithMessage("ImageURL is required.");
    }
}
