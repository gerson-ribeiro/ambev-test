using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Promotions.GetPromotion;

public class GetPromotionQuery : IRequest<GetPromotionResult>
{
    public Guid Id { get; set; }
}
