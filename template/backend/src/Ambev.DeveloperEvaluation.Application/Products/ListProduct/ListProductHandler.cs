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

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

public class ListProductHandler: IRequestHandler<ListProductQuery, ListProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ListProductResult> Handle(ListProductQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _productRepository.CountAsync(cancellationToken);
        var products = await _productRepository.GetAllAsync(request, cancellationToken);
        return new ListProductResult
        {

            CurrentPage = request.PageNumber == 0 ? 1 : request.PageNumber,
            PageSize = request.PageSize == 0 ? 30 : request.PageSize,
            TotalCount = totalCount,
            TotalPages = totalCount / (request.PageSize == 0 ? 30 : request.PageSize),
            Items = products.Select(c => _mapper.Map<ListProductItemResult>(c)).ToList()
        };
    }
}
