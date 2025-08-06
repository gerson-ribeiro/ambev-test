using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category entity, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetAllAsync(ListCategoryQuery query, CancellationToken cancellationToken);
        Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Category entity, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);
    }
}