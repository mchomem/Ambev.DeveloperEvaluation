using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Products).NotEmpty();
        RuleForEach(c => c.Products).SetValidator(new ProductRequestValidator());
    }
}
