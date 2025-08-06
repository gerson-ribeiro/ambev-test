using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public  class GetProductResult
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string Sku { get; set; }
    public string BarCode { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double OriginalPrice { get; set; }
    public bool Active { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = new("", "");
    public List<Guid> PromotionIds { get; set; } = new();

    public List<Promotion> Promotions { get; set; } = new List<Promotion>();
    
    public GetProductResult(Guid id, string identification, string sku, string barCode, string imageURL, string description, double originalPrice, bool active, Category category, List<Promotion> promotions)
    {
        Id = id;
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
    
}
