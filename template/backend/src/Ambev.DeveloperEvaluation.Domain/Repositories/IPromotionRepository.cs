using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public interface IPromotionRepository
    {
        Task<Promotion> CreateAsync(Promotion entity, CancellationToken cancellationToken);
        Task<IEnumerable<Promotion>> GetAllAsync(ListPromotionQuery query, CancellationToken cancellationToken);
        Task<Promotion?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Promotion entity, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);
    }
}