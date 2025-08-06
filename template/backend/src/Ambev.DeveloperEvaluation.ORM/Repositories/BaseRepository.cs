using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public abstract class BaseRepository<T> where T : class
{
    protected DefaultContext context;
    protected BaseRepository(DefaultContext context)
    {
        this.context = context;
    }

    public abstract Task<T> CreateAsync(T entity, CancellationToken  cancellationToken);
    public abstract Task<T?> GetByIdAsync(Guid id, CancellationToken  cancellationToken);
    public abstract Task<bool> UpdateAsync(T entity, CancellationToken  cancellationToken);
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        context.Set<T>().Remove(entity);

        return true;
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return await context.Categories.CountAsync(cancellationToken);
    }
}
