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
/// Implementation of ProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetAllAsync(ListProductQuery query, CancellationToken cancellationToken)
    {
        return await context.Products
            .Include(p => p.Category)
            .Include(p => p.Promotions)
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken)
    {
        await context.Products.AddAsync(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Products
            .Include(p => p.Category)
            .Include(p => p.Promotions)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<bool> UpdateAsync(Product entity, CancellationToken cancellationToken)
    {
        context.Products.Update(entity);
        return (await context.SaveChangesAsync(cancellationToken)) >0;
    }
}
