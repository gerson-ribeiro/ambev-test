using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.SaleNumber)
            .GreaterThan(0).WithMessage("Sale number must be greater than 0.");
        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future.");
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");
        RuleFor(x => x.Total)
            .GreaterThan(0).WithMessage("Total must be greater than 0.");
        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch ID is required.");
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Status must be a valid SaleStatus enum value.");
        RuleForEach(x => x.Items)
            .ChildRules(items =>
            {
                items.RuleFor(item => item.ProductId)
                    .NotEmpty().WithMessage("Product ID is required.");

                items.RuleFor(item => item.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                    .LessThan(20).WithMessage("Maximum limit is 20 items per product");

                items.RuleFor(item => item.UnitPrice)
                    .GreaterThan(0).WithMessage("Unit price must be greater than 0");
            });
    }
}
