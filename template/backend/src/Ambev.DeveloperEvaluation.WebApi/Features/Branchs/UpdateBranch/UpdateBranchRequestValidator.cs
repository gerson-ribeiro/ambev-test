using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch;

public class UpdateBranchRequestValidator : AbstractValidator<UpdateBranchRequest>
{
    public UpdateBranchRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Branch Id is required.")
            .Must(id => id != Guid.Empty).WithMessage("Branch Id must be a valid GUID.");

        RuleFor(x => x.BranchIdentifier)
            .NotEmpty().WithMessage("Branch Identifier is required.");

        RuleFor(x => x.BranchNumber)
            .NotEmpty().WithMessage("Branch Number is required.");
    }
}
