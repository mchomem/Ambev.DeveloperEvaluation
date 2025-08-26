using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class RatingRequestValidator : AbstractValidator<RatingRequest>
{
    public RatingRequestValidator()
    {
        RuleFor(r => r.Rate).InclusiveBetween(0, 5);
        RuleFor(r => r.Count).GreaterThanOrEqualTo(0);
    }
}
