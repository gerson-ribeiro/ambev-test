using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleRequest, GetSaleQuery>();
        CreateMap<GetSaleResult, GetSaleResponse>();
        CreateMap<GetSaleUserResult, GetSaleUserResponse>();
        CreateMap<GetSaleBranchResult, GetSaleBranchResponse>();
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
        CreateMap<GetSaleItemProductResult, GetSaleItemProductResponse>();
        CreateMap<GetSaleItemCategoryResult, GetSaleItemCategoryResponse>();

    }
}
