using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommand :IRequest<CreateProductResult>
{
    public string Identification { get; set; }
    public string Sku { get; set; }
    public string BarCode { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double OriginalPrice { get; set; }
    public bool Active { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public List<Guid> PromotionIds { get; set; } = new();
    public List<Promotion>? Promotions { get; set; } = new List<Promotion>();

    public CreateProductCommand(string identification, string sku, string barCode, string imageURL, string description, double originalPrice, bool active, Category category, List<Promotion> promotions)
    {
        Identification = identification;
        Sku = sku;
        BarCode = barCode;
        ImageURL = imageURL;
        Description = description;
        OriginalPrice = originalPrice;
        Active = active;
        Category = category;
        Promotions = promotions;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }
}
