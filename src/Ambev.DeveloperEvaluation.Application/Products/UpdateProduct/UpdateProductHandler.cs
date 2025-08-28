using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingProduct == null)
            throw new KeyNotFoundException($"Product with ID {command.Id} not found");

        var product = _mapper.Map<Product>(command);
        product.UpdatedAt = DateTimeOffset.UtcNow;
        product.SetRating(command.RatingRate, command.RatingCount);

        var updatedProduct = await _productRepository.UpdateAsync(product, cancellationToken);
        var result = _mapper.Map<UpdateProductResult>(updatedProduct);
        return result;
    }
}
