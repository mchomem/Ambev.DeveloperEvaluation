using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;

public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    public ProductRequestValidator()
    {
        RuleFor(p => p.ProductId).NotEmpty();
        RuleFor(p => p.Quantity).GreaterThan(0);
    }
}
