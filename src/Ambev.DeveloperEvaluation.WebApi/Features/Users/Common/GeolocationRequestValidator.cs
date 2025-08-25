using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.Common;

public class GeolocationRequestValidator : AbstractValidator<GeolocationRequest>
{
    public GeolocationRequestValidator()
    {
        RuleFor(g => g.Latitude).NotEmpty().MaximumLength(50);
        RuleFor(g => g.Longitude).NotEmpty().MaximumLength(50);
    }
}
