using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class RatingValidator : AbstractValidator<Rating>
{
    public RatingValidator()
    {
        RuleFor(r => r.Rate)
            .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5.");

        RuleFor(r => r.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Rating count cannot be negative.");
    }
}
