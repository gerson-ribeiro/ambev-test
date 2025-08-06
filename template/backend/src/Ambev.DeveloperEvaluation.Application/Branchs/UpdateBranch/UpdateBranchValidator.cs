using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

public class UpdateBranchValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchValidator()
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
