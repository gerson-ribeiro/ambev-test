using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductProfile : Profile
{
    public ListProductProfile()
    {
        CreateMap<ListProductRequest, ListProductQuery>();
        CreateMap<ListProductResult, ListProductResponse>();
        CreateMap<ListProductItemResult, ListProductItemResponse>();
        CreateMap<ListProductPromotionResult, ListProductPromotionResponse>();
    }
}