using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(x => x.SaleNumber)
            .GreaterThan(0).WithMessage("Sale number must be greater than 0.");
        RuleFor(x => x.Total)
            .GreaterThan(0).WithMessage("Total must be greater than 0.");
        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch ID must not be empty.")
            .Must(id => id != Guid.Empty).WithMessage("Branch ID must be a valid GUID.");
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Status must be a valid SaleStatus enum value.");
    }
}
