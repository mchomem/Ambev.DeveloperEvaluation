using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart;

public class CreateCartResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty; // TODO:  Aplicar um mapeamento customizado para DateTimeOffSet para string.
    public List<ProductResponse> Products { get; set; } = new();
}
