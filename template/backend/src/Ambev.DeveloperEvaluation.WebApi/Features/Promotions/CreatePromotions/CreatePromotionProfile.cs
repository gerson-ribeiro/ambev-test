using Ambev.DeveloperEvaluation.Application.Promotions.CreatePromotion;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.CreatePromotions;

public class CreatePromotionProfile : Profile
{
    public CreatePromotionProfile()
    {
        CreateMap<CreatePromotionRequest, CreatePromotionCommand>();
    }
}
