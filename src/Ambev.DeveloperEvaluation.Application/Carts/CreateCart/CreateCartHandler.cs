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

        // Agrupar itens pelo ProductId para calcular descontos corretamente
        var groupedProducts = command.Products
            .GroupBy(p => p.ProductId)
            .Select(g => new 
            { 
                ProductId = g.Key, 
                TotalQuantity = g.Sum(p => p.Quantity) 
            })
            .ToList();

        // Verificar limite máximo de itens por produto
        foreach (var group in groupedProducts)
        {
            if (group.TotalQuantity > 20)
                throw new InvalidOperationException($"You cannot sell more than 20 items of the same product. Product ID: {group.ProductId} has {group.TotalQuantity} items.");
        }

        // Criar o carrinho e seus itens com preços e descontos calculados
        var cart = _mapper.Map<Cart>(command);
        cart.User = user;
        cart.Date = DateTimeOffset.UtcNow;
        
        // Limpar os itens mapeados automaticamente e criar com as regras de negócio
        cart.CartItens = new List<CartItem>();
        
        decimal totalSale = 0;
        decimal totalSaleDiscount = 0;

        // Processar cada item do carrinho
        foreach (var productCommand in command.Products)
        {
            var product = await _productRepository.GetByIdAsync(productCommand.ProductId, cancellationToken);
            
            if (product is null)
                throw new KeyNotFoundException($"Product with ID {productCommand.ProductId} not found");

            var quantity = productCommand.Quantity;
            var unitPrice = product.Price;
            var totalItemPrice = unitPrice * quantity;
            
            // Encontrar a quantidade total deste produto no carrinho para determinar o desconto
            var totalProductQuantity = groupedProducts
                .FirstOrDefault(g => g.ProductId == productCommand.ProductId)?.TotalQuantity ?? 0;
            
            // Calcular desconto baseado na quantidade total do produto
            decimal discountPercentage = 0;
            
            if (totalProductQuantity >= 10 && totalProductQuantity <= 20)
            {
                // 20% de desconto para compras entre 10 e 20 itens
                discountPercentage = 0.20m;
            }
            else if (totalProductQuantity >= 4)
            {
                // 10% de desconto para compras com 4 ou mais itens
                discountPercentage = 0.10m;
            }
            
            decimal itemDiscount = totalItemPrice * discountPercentage;
            decimal finalItemPrice = totalItemPrice - itemDiscount;
            
            // Adicionar ao total geral
            totalSale += totalItemPrice;
            totalSaleDiscount += itemDiscount;
            
            // Criar o item do carrinho
            var cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Product = product,
                Quantity = quantity,
                UnitPrice = unitPrice
            };
            
            cart.CartItens.Add(cartItem);
        }
        
        // Atualizar totais do carrinho
        cart.TotalSale = totalSale;
        cart.TotalSaleDiscount = totalSaleDiscount;
        
        var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);
        return result;
    }
}
