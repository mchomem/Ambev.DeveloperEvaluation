using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidatior : AbstractValidator<Product>
{
    public ProductValidatior()
    {
        RuleFor(product => product.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1000).WithMessage("Description cannot be longer than 1000 characters.");

        RuleFor(product => product.Category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(100).WithMessage("Category cannot be longer than 100 characters.");

        RuleFor(product => product.Image)
            .NotEmpty().WithMessage("Image URL is required.")
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("Image must be a valid URL.");

        // Value Object Rating validation.
        RuleFor(product => product.Rating)
            .SetValidator(new RatingValidator());
    }
}
