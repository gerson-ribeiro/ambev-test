using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchValidator : AbstractValidator<GetBranchQuery>
{
    public GetBranchValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Branch Id is required.")
            .Must(id => id != Guid.Empty).WithMessage("Branch Id must be a valid GUID.");
    }
}
