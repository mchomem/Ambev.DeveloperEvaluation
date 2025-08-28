using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> GetAllProductCategoryAsync();
    Task<IEnumerable<Product>> GetProductsBySpecificCategoryAsync(string category, CancellationToken cancellationToken = default);
}
