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

namespace Ambev.DeveloperEvaluation.Application.Promotions.ListPromotion;

public class ListPromotionHandler : IRequestHandler<ListPromotionQuery, ListPromotionResult>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IMapper _mapper;

    public ListPromotionHandler(IPromotionRepository promotionRepository, IMapper mapper)
    {
        _promotionRepository = promotionRepository;
        _mapper = mapper;
    }

    public async Task<ListPromotionResult> Handle(ListPromotionQuery request, CancellationToken cancellationToken)
    {
        var promotions = await _promotionRepository.GetAllAsync(request, cancellationToken);
        var totalCount = await _promotionRepository.CountAsync(cancellationToken);
        return new ListPromotionResult
        {
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize),
            Items = _mapper.Map<IList<ListPromotionItemResult>>(promotions)
        };
    }
}
