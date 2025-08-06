using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using Ambev.DeveloperEvaluation.WebApi.Features.Promotions.GetPromotions;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions.ListPromotions;

public class ListPromotionProfile : Profile
{
    public ListPromotionProfile()
    {
        CreateMap<ListPromotionRequest, ListPromotionQuery>();
        CreateMap<ListPromotionResult, ListPromotionResponse>();
        CreateMap<ListPromotionItemResult, ListPromotionItemResponse>();
    }

}
