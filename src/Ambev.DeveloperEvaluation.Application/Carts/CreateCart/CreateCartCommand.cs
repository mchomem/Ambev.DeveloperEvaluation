using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty;
    public List<ProductCommand> Products { get; set; } = new();

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartCommandValidator();
        var result = validator.Validate(this);

        return new ValidationResultDetail()
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
