using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Entry(cart.User).State = EntityState.Unchanged;

        if (cart.CartItens != null)
        {
            foreach (var item in cart.CartItens)
            {
                if (item.Product != null)
                {
                    _context.Entry(item.Product).State = EntityState.Unchanged;
                }
            }
        }

        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<Cart> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);

        if (cart is null)
            return null!;

        if (cart.CartItens is not null)
        {
            _context.CartItems.RemoveRange(cart.CartItens);
        }
        
        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public IQueryable<Cart> GetAll()
    {
        var carts = _context.Carts.AsNoTracking();
        return carts;
    }

    public async Task<Cart> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Carts
            .Include(c => c.User)
            .Include(c => c.CartItens)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        return cart;
    }

    public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }
}
