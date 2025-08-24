using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(); // TODO: Implement pagination
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<string>> GetAllProductCategoryAsync(); // TODO: Implement pagination
    Task<IEnumerable<Product>> GetProductsBySpecificCategoryAsync(string category, CancellationToken cancellationToken = default); // TODO: Implement pagination
}
