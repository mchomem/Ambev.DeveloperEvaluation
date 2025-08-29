using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.DeleteCart;

public class DeleteCartResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty;
    public List<ProductResponse> Products { get; set; } = new();
}
