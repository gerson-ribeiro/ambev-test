using Ambev.DeveloperEvaluation.Application.Categories.GetCategory;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Promotions.GetPromotion;

public class GetPromotionHandler : IRequestHandler<GetPromotionQuery, GetPromotionResult>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IMapper _mapper;
    public GetPromotionHandler(IPromotionRepository promotionRepository, IMapper mapper)
    {
        _promotionRepository = promotionRepository;
        _mapper = mapper;
    }
    public async Task<GetPromotionResult> Handle(GetPromotionQuery request, CancellationToken cancellationToken)
    {

        var entity = await _promotionRepository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null)
            throw new Exception($"Category with ID {request.Id} not found.");

        return _mapper.Map<GetPromotionResult>(entity);
    }
}
