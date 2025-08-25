using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.Common;

public class NameRequestValidator : AbstractValidator<NameRequest>
{
    public NameRequestValidator()
    {
        RuleFor(name => name.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(name => name.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
    }
}
