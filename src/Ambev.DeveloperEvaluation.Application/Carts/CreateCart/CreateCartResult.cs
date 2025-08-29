using Ambev.DeveloperEvaluation.Application.Carts.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartResult
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty; // TODO:  Aplicar um mapeamento customizado para DateTimeOffSet para string.
    public List<ProductResult> Products { get; set; } = new();
}
