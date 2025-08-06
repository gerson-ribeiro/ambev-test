using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;

public class CreateCategoryCommand : IRequest<CreateCategoryResult>
{

    public string Identification { get; set; }
    public string DisplayName { get; set; }

    public CreateCategoryCommand(string identification, string displayName)
    {
        Identification = identification;
        DisplayName = displayName;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCategoryValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }
}
