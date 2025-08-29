using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.DeleteCart;

public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
{
    public DeleteCartRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
