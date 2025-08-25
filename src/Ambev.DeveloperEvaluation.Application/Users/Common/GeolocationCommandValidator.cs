using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.Common;

public class GeolocationCommandValidator : AbstractValidator<GeolocationCommand>
{
    public GeolocationCommandValidator()
    {
        RuleFor(g => g.Latitude).NotEmpty().MaximumLength(50);
        RuleFor(g => g.Longitude).NotEmpty().MaximumLength(50);
    }
}
