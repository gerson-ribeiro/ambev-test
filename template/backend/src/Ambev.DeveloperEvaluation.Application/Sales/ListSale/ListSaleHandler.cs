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

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    public class ListSaleHandler : IRequestHandler<ListSaleQuery, ListSaleResult>
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;

        public ListSaleHandler(IMapper mapper, ISaleRepository saleRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }
        public async Task<ListSaleResult> Handle(ListSaleQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllAsync(request, cancellationToken);
            var totalCount = await _saleRepository.CountAsync(cancellationToken);

            return new ListSaleResult
            {
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize),
                Items = sales.Select(sale => _mapper.Map<ListSalesItemResult>(sale)).ToList()
            };
        }
    }
}
