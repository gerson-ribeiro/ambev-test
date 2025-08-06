using Ambev.DeveloperEvaluation.Application.Promotions.CreatePromotion;
using Ambev.DeveloperEvaluation.Application.Promotions.UpdatePromotion;
using Ambev.DeveloperEvaluation.WebApi.Features.Promotions.CreatePromotions;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.UpdatePromotions;

public class UpdatePromotionProfile : Profile
{
    public UpdatePromotionProfile()
    {
        CreateMap<UpdatePromotionRequest, UpdatePromotionCommand>();
    }
}
