using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Promotions.CreatePromotion;

public class CreatePromotionCommand : IRequest<CreatePromotionResult>
{
    public CreatePromotionCommand(string identification, double percent, int? maxUnit, int minUnit, DateTime? expirationDate)
    {
        Identification = identification;
        Percent = percent;
        MaxUnit = maxUnit;
        MinUnit = minUnit;
        ExpirationDate = expirationDate;
    }

    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreatePromotionValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }
}
