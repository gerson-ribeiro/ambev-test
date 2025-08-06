namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.CreatePromotions;

public class CreatePromotionRequest
{
    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }
}
