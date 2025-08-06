using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Promotions.UpdatePromotion;

public class UpdatePromotionHandler : IRequestHandler<UpdatePromotionCommand, bool>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IMapper _mapper;
    public UpdatePromotionHandler(IPromotionRepository promotionRepository, IMapper mapper)
    {
        _promotionRepository = promotionRepository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Entities.Promotion>(request);
        var updated = await _promotionRepository.UpdateAsync(entity, cancellationToken);

        return updated;
    }
}
