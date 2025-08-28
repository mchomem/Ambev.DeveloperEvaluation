using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProduct request
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID do produto � obrigat�rio");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("O t�tulo do produto � obrigat�rio")
            .MaximumLength(100)
            .WithMessage("O t�tulo do produto deve ter no m�ximo 100 caracteres");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O pre�o do produto deve ser maior ou igual a zero");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("A descri��o do produto � obrigat�ria")
            .MaximumLength(500)
            .WithMessage("A descri��o do produto deve ter no m�ximo 500 caracteres");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("A categoria do produto � obrigat�ria")
            .MaximumLength(50)
            .WithMessage("A categoria do produto deve ter no m�ximo 50 caracteres");

        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("A URL da imagem do produto � obrigat�ria")
            .MaximumLength(2000)
            .WithMessage("A URL da imagem do produto deve ter no m�ximo 2000 caracteres");

        RuleFor(x => x.Rating.Rate)
            .InclusiveBetween(0, 5)
            .WithMessage("A avalia��o do produto deve estar entre 0 e 5");

        RuleFor(x => x.Rating.Count)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O n�mero de avalia��es deve ser maior ou igual a zero");
    }
}