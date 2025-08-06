using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class BranchRepository : BaseRepository<Branch>, IBranchRepository
{
    /// <summary>
    /// Initializes a new instance of BranchRepository
    /// </summary>
    /// <param name="context"> The database context</param>
    public BranchRepository(DefaultContext context) : base(context)
    {
    }

    public override async Task<Branch> CreateAsync(Branch entity, CancellationToken cancellationToken)
    {
        await context.Branches.AddAsync(entity, cancellationToken);

        await context.SaveChangesAsync();

        return entity;
    }

    public override async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Branches.FindAsync(id, cancellationToken);
    }

    public override Task<bool> UpdateAsync(Branch entity, CancellationToken cancellationToken)
    {
        context.Branches.Update(entity);
        return context.SaveChangesAsync(cancellationToken).ContinueWith(t => t.Result > 0);
    }
}
