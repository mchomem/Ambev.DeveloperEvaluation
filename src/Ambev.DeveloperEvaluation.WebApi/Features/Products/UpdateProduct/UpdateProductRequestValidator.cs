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
            .WithMessage("O ID do produto é obrigatório");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("O título do produto é obrigatório")
            .MaximumLength(100)
            .WithMessage("O título do produto deve ter no máximo 100 caracteres");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O preço do produto deve ser maior ou igual a zero");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("A descrição do produto é obrigatória")
            .MaximumLength(500)
            .WithMessage("A descrição do produto deve ter no máximo 500 caracteres");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("A categoria do produto é obrigatória")
            .MaximumLength(50)
            .WithMessage("A categoria do produto deve ter no máximo 50 caracteres");

        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("A URL da imagem do produto é obrigatória")
            .MaximumLength(2000)
            .WithMessage("A URL da imagem do produto deve ter no máximo 2000 caracteres");

        RuleFor(x => x.Rating.Rate)
            .InclusiveBetween(0, 5)
            .WithMessage("A avaliação do produto deve estar entre 0 e 5");

        RuleFor(x => x.Rating.Count)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O número de avaliações deve ser maior ou igual a zero");
    }
}