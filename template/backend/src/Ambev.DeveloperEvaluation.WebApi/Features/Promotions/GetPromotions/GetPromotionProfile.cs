using Ambev.DeveloperEvaluation.Application.Promotions.GetPromotion;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.GetPromotions;

public class GetPromotionProfile : Profile
{
    public GetPromotionProfile()
    {
        CreateMap<GetPromotionRequest, GetPromotionQuery>();
        CreateMap<GetPromotionResult, GetPromotionResponse>();
    }
}
