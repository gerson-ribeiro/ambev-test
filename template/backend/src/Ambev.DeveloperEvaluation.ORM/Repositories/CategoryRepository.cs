using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetAllAsync(ListCategoryQuery query, CancellationToken cancellationToken)
    {
        return await context.Categories
            .Include(c=> c.Promotions)
            .Skip((query.PageNumber-1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
    }

    public override async Task<Category> CreateAsync(Category entity, CancellationToken cancellationToken)
    {
        await context.Categories.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Categories
            .Include(c => c.Promotions)
            .FirstOrDefaultAsync(c=> c.Id == id);
    }

    public override Task<bool> UpdateAsync(Category entity, CancellationToken cancellationToken)
    {
        context.Categories.Update(entity);
        return context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
    }
}
