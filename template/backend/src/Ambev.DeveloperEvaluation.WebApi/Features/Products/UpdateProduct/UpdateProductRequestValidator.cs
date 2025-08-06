using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Identification)
            .NotEmpty().WithMessage("Identification is required.")
            .MaximumLength(100).WithMessage("Identification must not exceed 100 characters.");
        RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("SKU is required.")
            .MaximumLength(50).WithMessage("SKU must not exceed 50 characters.");
        RuleFor(x => x.BarCode)
            .NotEmpty().WithMessage("BarCode is required.")
            .MaximumLength(20).WithMessage("BarCode must not exceed 20 characters.");
        RuleFor(x => x.ImageURL)
            .NotEmpty().WithMessage("ImageURL is required.")
            .MaximumLength(200).WithMessage("ImageURL must not exceed 200 characters.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        RuleFor(x => x.OriginalPrice)
            .GreaterThanOrEqualTo(0).WithMessage("OriginalPrice must be a non-negative value.");
        RuleFor(x => x.Active)
            .NotNull().WithMessage("Active status is required.");
    }
}
