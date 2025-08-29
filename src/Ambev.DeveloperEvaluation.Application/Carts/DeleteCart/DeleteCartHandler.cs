using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public DeleteCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingCart is null)
            throw new InvalidOperationException("Cart not found.");

        var deletedCart = await _cartRepository.DeleteAsync(request.Id, cancellationToken);
        var result = _mapper.Map<DeleteCartResult>(deletedCart);
        return result;
    }
}
