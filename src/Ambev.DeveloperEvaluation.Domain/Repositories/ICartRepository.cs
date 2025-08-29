using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository
{
    IQueryable<Cart> GetAll();
    Task<Cart> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<Cart> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
