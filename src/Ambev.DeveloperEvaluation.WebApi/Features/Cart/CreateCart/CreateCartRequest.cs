using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart;

public class CreateCartRequest
{
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty;
    public List<ProductRequest> Products { get; set; } = new();
}
