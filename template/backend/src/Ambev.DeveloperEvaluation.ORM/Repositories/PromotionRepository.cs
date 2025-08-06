using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of PromotionRepository using Entity Framework Core
/// </summary>
public class PromotionRepository : BaseRepository<Promotion>, IPromotionRepository
{
    public PromotionRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Promotion>> GetAllAsync(ListPromotionQuery query, CancellationToken cancellationToken)
    {
        return await context.Promotions
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Promotion> CreateAsync(Promotion entity, CancellationToken cancellationToken)
    {
        await context.Promotions.AddAsync(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
    public override async Task<Promotion?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Promotions.FindAsync(new { Id = id }, cancellationToken);
    }
    public override Task<bool> UpdateAsync(Promotion entity, CancellationToken cancellationToken)
    {
        context.Promotions.Update(entity);
        return context.SaveChangesAsync(cancellationToken).ContinueWith(t => t.Result > 0);
    }
}
