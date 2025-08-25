using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.Common;

public class AddressCommandValidator : AbstractValidator<AddressCommand>
{
    public AddressCommandValidator()
    {
        RuleFor(a => a.City).NotEmpty().MaximumLength(100);
        RuleFor(a => a.Street).NotEmpty().MaximumLength(100);
        RuleFor(a => a.Number).GreaterThan(0);
        RuleFor(a => a.Zipcode).NotEmpty().MaximumLength(20);
        RuleFor(a => a.Geolocation).SetValidator(new GeolocationCommandValidator());
    }
}
