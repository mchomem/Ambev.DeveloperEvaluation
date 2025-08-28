using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title).NotEmpty().MaximumLength(100);
        RuleFor(product => product.Price).GreaterThan(0);
        RuleFor(product => product.Description).NotEmpty().MaximumLength(1000);
        RuleFor(product => product.Category).NotEmpty().MaximumLength(100);
        RuleFor(product => product.Image).NotEmpty().Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute));
        RuleFor(product => product.Rating).SetValidator(new RatingRequestValidator());
    }
}
