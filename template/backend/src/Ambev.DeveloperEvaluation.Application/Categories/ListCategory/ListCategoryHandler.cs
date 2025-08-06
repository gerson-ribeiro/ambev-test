using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.ListCategory;

public class ListCategoryHandler : IRequestHandler<ListCategoryQuery, ListCategoryResult>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public ListCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }


    public async Task<ListCategoryResult> Handle(ListCategoryQuery request, CancellationToken cancellationToken)
    {
        /// validar request
        /// 

        var totalCount = await _categoryRepository.CountAsync(cancellationToken);
        var result = await _categoryRepository.GetAllAsync(request, cancellationToken);

        return new ListCategoryResult
        {
            CurrentPage = request.PageNumber == 0 ? 1 : request.PageNumber,
            PageSize = request.PageSize == 0 ? 30 : request.PageSize,
            TotalCount = totalCount,
            TotalPages = totalCount / (request.PageSize == 0 ? 30 : request.PageSize),
            Items = result.Select(c => _mapper.Map<ListCategoryItemResult>(c)).ToList()
        };
    }
}
