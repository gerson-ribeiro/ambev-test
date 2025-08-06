namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.UpdatePromotions;

public class UpdatePromotionRequest
{
    public Guid Id { get; set; }
    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }
}
