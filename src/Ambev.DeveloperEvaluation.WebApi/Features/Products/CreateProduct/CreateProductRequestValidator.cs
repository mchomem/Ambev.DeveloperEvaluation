using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Title).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Description).NotEmpty().MaximumLength(1000);
        RuleFor(p => p.Category).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Image).NotEmpty().Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute));
        RuleFor(p => p.Rating).SetValidator(new RatingRequestValidator());
    }
}
