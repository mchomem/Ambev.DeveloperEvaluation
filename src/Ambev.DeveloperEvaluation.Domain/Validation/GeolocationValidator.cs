using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class GeolocationValidator : AbstractValidator<Geolocation>
{
    public GeolocationValidator()
    {
        RuleFor(g => g.Latitude)
            .NotEmpty().WithMessage("Latitude is required.")
            .MaximumLength(50).WithMessage("Latitude cannot be longer than 50 characters.");

        RuleFor(g => g.Longitude)
            .NotEmpty().WithMessage("Longitude is required.")
            .MaximumLength(50).WithMessage("Longitude cannot be longer than 50 characters.");
    }
}
