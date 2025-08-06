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
/// Implementation of SaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    public SaleRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Sale>> GetAllAsync(ListSaleQuery query, CancellationToken cancellationToken)
    {
        return await context.Sales
            .Include(s => s.Items)
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Sale> CreateAsync(Sale entity, CancellationToken cancellationToken)
    {
        await context.Sales.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public override async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public override Task<bool> UpdateAsync(Sale entity, CancellationToken cancellationToken)
    {
        context.Sales.Update(entity);
        return context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
    }
}
