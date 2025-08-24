using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class RatingCommandValidator : AbstractValidator<RatingCommand>
{
    public RatingCommandValidator()
    {
        RuleFor(r => r.Rate).InclusiveBetween(0, 5);
        RuleFor(r => r.Count).GreaterThanOrEqualTo(0);
    }
}
