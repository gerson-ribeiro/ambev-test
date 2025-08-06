using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch> CreateAsync(Branch entity, CancellationToken cancellationToken);
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Branch entity, CancellationToken cancellationToken);
    }
}