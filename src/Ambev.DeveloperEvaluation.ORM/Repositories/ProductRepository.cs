using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);

        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _context.Products
            .AsNoTracking()
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<string>> GetAllProductCategoryAsync()
    {
        var productCategories = await _context.Products
            .AsNoTracking()
            .Select(p => p.Category)
            .Distinct()
            .ToListAsync();
        return productCategories;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        return result;
    }

    public async Task<IEnumerable<Product>> GetProductsBySpecificCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        var products = await _context.Products
            .Where(x => x.Category == category)
            .ToListAsync();
        return products;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
}
