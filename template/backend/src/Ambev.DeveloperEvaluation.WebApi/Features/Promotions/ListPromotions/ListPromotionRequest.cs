namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.ListPromotions;

public class ListPromotionRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;


    public string Identification { get; set; } = string.Empty;
    public double Percent { get; set; } = 0;
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; } = 0;
    public DateTime? StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
}
