using Ambev.DeveloperEvaluation.Application.Common.Pagination;
using Ambev.DeveloperEvaluation.Application.Common.Queries;
using Ambev.DeveloperEvaluation.Application.Users.ListUsers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsCommand, PaginatedList<ListProductsResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ListProductsResult>> Handle(ListProductsCommand request, CancellationToken cancellationToken)
    {
        var query = _productRepository.GetAll();

        query = query
            .ApplyFilters(request.Options.Filters)
            .ApplyOrdering(request.Options.Order);

        var pageEntity = await PaginatedList<Product>.CreateAsync(query, request.Options.Page, request.Options.Size);
        var itens = _mapper.Map<List<ListProductsResult>>(pageEntity);
        
        return new PaginatedList<ListProductsResult>(itens, pageEntity.TotalCount, pageEntity.CurrentPage, pageEntity.PageSize);
    }
}
