namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class Cart
{
    public Cart()
    {
        CartItens = new List<CartItem>();
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int SaleNumber { get; set; }
    public DateTimeOffset Date { get; set; }

    #region Navigation

    public User User { get; set; }
    public ICollection<CartItem> CartItens { get; set; }

    #endregion
}
