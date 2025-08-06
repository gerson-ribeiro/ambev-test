using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

public class ListSaleProfile : Profile
{
    public ListSaleProfile()
    {
        CreateMap<ListSaleRequest, ListSaleQuery>();
        CreateMap<ListSaleResult, ListSaleResponse>();
        CreateMap<GetSaleUserResult, GetSaleUserResponse>();
        CreateMap<GetSaleBranchResult, GetSaleBranchResponse>();
        CreateMap<ListSalesItemResult, GetSaleResponse>();
        CreateMap<ListSaleItemItemsResult, GetSaleItemResponse>();
        CreateMap<ListSaleItemItemsProductResult, GetSaleItemProductResponse>();
        CreateMap<ListSaleItemItemsProductCategoryResult, GetSaleItemCategoryResponse>();

    }
}
