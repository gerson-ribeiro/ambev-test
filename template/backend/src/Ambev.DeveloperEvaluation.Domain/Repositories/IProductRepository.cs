using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAllAsync(ListProductQuery query, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Product entity, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);
    }
}