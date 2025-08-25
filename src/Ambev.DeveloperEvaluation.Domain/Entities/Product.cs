using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class Product : BaseEntity
{
    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    #region Value Objects

    public Rating Rating { get; private set; } = new Rating(0, 0);

    public void SetRating(decimal rate, int count)
    {
        Rating = new Rating(rate, count);
        UpdatedAt = DateTime.UtcNow;
    }

    #endregion

    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidatior();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
