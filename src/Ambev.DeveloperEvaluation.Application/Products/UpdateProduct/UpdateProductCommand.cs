using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Command for updating a product
/// </summary>
public class UpdateProductCommand : IRequest<UpdateProductResult>
{
    /// <summary>
    /// The unique identifier of the product to update
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the title of the product
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the price of the product
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Gets or sets the description of the product
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the category of the product
    /// </summary>
    public string Category { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the image URL of the product
    /// </summary>
    public string Image { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the rating rate of the product
    /// </summary>
    public decimal RatingRate { get; set; }
    
    /// <summary>
    /// Gets or sets the rating count of the product
    /// </summary>
    public int RatingCount { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateProductValidator();
        var result = validator.Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
