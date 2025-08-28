using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated product
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
    /// Gets or sets the date rating
    /// </summary>
    public RatingResult Rating { get; set; } = new();
}
