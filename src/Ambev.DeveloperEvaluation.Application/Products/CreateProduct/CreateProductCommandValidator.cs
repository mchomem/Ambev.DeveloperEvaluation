using Ambev.DeveloperEvaluation.Application.Products.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Title).NotEmpty().MaximumLength(100);
        RuleFor(product => product.Price).GreaterThan(0);
        RuleFor(product => product.Description).NotEmpty().MaximumLength(1000);
        RuleFor(product => product.Category).NotEmpty().MaximumLength(100);
        RuleFor(product => product.Image).NotEmpty().Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute));
        RuleFor(product => product.Rating).SetValidator(new RatingCommandValidator());
    }
}
