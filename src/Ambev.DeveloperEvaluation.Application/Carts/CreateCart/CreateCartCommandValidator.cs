using Ambev.DeveloperEvaluation.Application.Carts.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty();
        RuleFor(cart => cart.Products).NotNull();
        RuleForEach(cart => cart.Products).SetValidator(new ProductCommandValidator());
    }
}
