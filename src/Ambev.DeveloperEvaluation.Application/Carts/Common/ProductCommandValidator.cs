using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Common;

public class ProductCommandValidator : AbstractValidator<ProductCommand>
{
    public ProductCommandValidator()
    {
        RuleFor(product => product.ProductId).NotEmpty();
        RuleFor(product => product.Quantity).GreaterThan(0);
    }
}
