using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
{
    public CreateBranchRequestValidator()
    {
        RuleFor(x => x.BranchIdentifier)
            .NotEmpty().WithMessage("BranchIdentifier is required.")
            .MaximumLength(50).WithMessage("BranchIdentifier must not exceed 50 characters.");
        RuleFor(x => x.BranchNumber)
            .NotEmpty().WithMessage("BranchNumber is required.")
            .MaximumLength(20).WithMessage("BranchNumber must not exceed 20 characters.");
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("CompanyName is required.")
            .MaximumLength(100).WithMessage("CompanyName must not exceed 100 characters.");
        RuleFor(x => x.Partner)
            .NotEmpty().WithMessage("Partner is required.")
            .MaximumLength(100).WithMessage("Partner must not exceed 100 characters.");
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");
        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("Number is required.")
            .MaximumLength(10).WithMessage("Number must not exceed 10 characters.");
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City must not exceed 100 characters.");
        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required.")
            .MaximumLength(100).WithMessage("State must not exceed 100 characters.");
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100).WithMessage("Country must not exceed 100 characters.");
        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("PostalCode is required.")
            .MaximumLength(20).WithMessage("PostalCode must not exceed 20 characters.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.");
        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("EmailAddress is required.")
            .EmailAddress().WithMessage("EmailAddress must be a valid email address.");
    }
}
