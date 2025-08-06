using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> CreateAsync(Sale entity, CancellationToken cancellationToken);
        Task<IEnumerable<Sale>> GetAllAsync(ListSaleQuery query, CancellationToken cancellationToken);
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Sale entity, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);
    }
}