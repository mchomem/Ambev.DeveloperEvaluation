using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.Common;

public class NameCommandValidator : AbstractValidator<NameCommand>
{
    public NameCommandValidator()
    {
        RuleFor(name => name.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(name => name.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
    }
}
