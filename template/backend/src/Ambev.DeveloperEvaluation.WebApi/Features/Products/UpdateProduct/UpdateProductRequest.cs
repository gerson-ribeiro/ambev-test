using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductRequest
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
    public Category? Category { get; set; }

    public List<Guid> PromotionIds { get; set; } = new();
    public List<Promotion> Promotions { get; set; } = new List<Promotion>();
}
