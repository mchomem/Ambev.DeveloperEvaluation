using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateCartHandler(ICartRepository cartRepository, IUserRepository _userRepositorym, IProductRepository productRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _userRepository = _userRepositorym;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (user is null)
            throw new KeyNotFoundException($"User with ID {command.UserId} not found");

        var productIds = command.Products.Select(product => product.ProductId);

        foreach (var productId in productIds)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productId);

            if (existingProduct is null)
                throw new KeyNotFoundException($"Product with ID {productId} not found");
        }

        // TODO: por enquanto deixar as regras de compras aqui.

        var cart = _mapper.Map<Cart>(command);
        cart.User = user;
        var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);
        return result;
    }
}
