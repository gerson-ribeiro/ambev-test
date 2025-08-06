using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchValidator()
    {
        RuleFor(x => x.BranchIdentifier)
            .NotEmpty().WithMessage("Branch Identifier is required.")
            .Length(1, 50).WithMessage("Branch Identifier must be between 1 and 50 characters.");
        RuleFor(x => x.BranchNumber)
            .NotEmpty().WithMessage("Branch Number is required.")
            .Length(1, 20).WithMessage("Branch Number must be between 1 and 20 characters.");
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company Name is required.")
            .Length(1, 100).WithMessage("Company Name must be between 1 and 100 characters.");
        RuleFor(x => x.Partner)
            .NotEmpty().WithMessage("Partner is required.")
            .Length(1, 100).WithMessage("Partner must be between 1 and 100 characters.");
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(1, 200).WithMessage("Address must be between 1 and 200 characters.");
        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("Number is required.")
            .Length(1, 10).WithMessage("Number must be between 1 and 10 characters.");
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .Length(1, 50).WithMessage("City must be between 1 and 50 characters.");
        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required.")
            .Length(2, 2).WithMessage("State must be exactly 2 characters.");
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .Length(2, 50).WithMessage("Country must be between 2 and 50 characters.");
        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal Code is required.")
            .Length(5, 10).WithMessage("Postal Code must be between 5 and 10 characters.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required.")
            .Matches(@"^\+?[0-9\s\-()]+$").WithMessage("Phone Number must be a valid format.");
    }
}
