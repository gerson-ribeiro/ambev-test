using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
{
    public ListProductRequestValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("PageNumber must be greater than 0.");
        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("PageSize must be greater than 0.")
            .LessThanOrEqualTo(100).WithMessage("PageSize must be less than or equal to 100.");
        RuleFor(x => x.Identification)
            .MaximumLength(50).WithMessage("Identification must not exceed 50 characters.");
        RuleFor(x => x.Sku)
            .MaximumLength(30).WithMessage("Sku must not exceed 30 characters.");
        RuleFor(x => x.BarCode)
            .MaximumLength(20).WithMessage("BarCode must not exceed 20 characters.");
        RuleFor(x => x.ImageURL)
            .MaximumLength(200).WithMessage("ImageURL must not exceed 200 characters.")
            .Must(uri => string.IsNullOrEmpty(uri) || Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("ImageURL must be a valid URL.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}
