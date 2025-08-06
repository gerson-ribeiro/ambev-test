using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product with associated details such as identification, pricing, category, and promotional information.
/// </summary>
/// <remarks>This class provides properties to define and manage a product's attributes, including its unique
/// identifiers, pricing, category and active status. It is designed to be used in scenarios
/// where product information  needs to be stored, retrieved, or manipulated, such as in e-commerce or inventory
/// management systems.</remarks>
public class Product : BaseEntity
{
    public string Identification { get; set; }
    public string Sku { get; set; }
    public string BarCode { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double OriginalPrice { get; set; }
    public bool Active { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Guid>? PromotionIds { get; set; } = new List<Guid>();
    public virtual IList<Promotion> Promotions { get; set; } = new List<Promotion>();
    public virtual IList<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public Product(string identification, string sku, string barCode, string imageURL, string description, double originalPrice,  bool active)
    {
        Identification = identification;
        Sku = sku;
        BarCode = barCode;
        ImageURL = imageURL;
        Description = description;
        OriginalPrice = originalPrice;
        Active = active;
    }
}
