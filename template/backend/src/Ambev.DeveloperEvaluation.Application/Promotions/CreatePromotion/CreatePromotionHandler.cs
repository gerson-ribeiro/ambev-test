using Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Promotions.CreatePromotion;

public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand, CreatePromotionResult>
{
    private readonly IMapper _mapper;
    private readonly IPromotionRepository _promotionRepository;
    public CreatePromotionHandler(IMapper mapper, IPromotionRepository promotionRepository)
    {
        _mapper = mapper;
        _promotionRepository = promotionRepository;
    }
    public async Task<CreatePromotionResult> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Promotion>(request);
        var created = await _promotionRepository.CreateAsync(entity, cancellationToken);

        return _mapper.Map<CreatePromotionResult>(created);
    }
}
