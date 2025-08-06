using Ambev.DeveloperEvaluation.Application.Categories.ListCategory;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategory;

public class ListCategoryProfile : Profile
{
    public ListCategoryProfile()
    {
        CreateMap<ListCategoryRequest, ListCategoryQuery>();
        CreateMap<ListCategoryResult, ListCategoryResponse>();
        CreateMap<ListCategoryItemResult, ListSaleItemResponse>();
    }
}
