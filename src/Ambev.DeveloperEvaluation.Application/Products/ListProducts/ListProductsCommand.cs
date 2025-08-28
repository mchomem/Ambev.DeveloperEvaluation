using Ambev.DeveloperEvaluation.Application.Common.Pagination;
using Ambev.DeveloperEvaluation.Application.Common.Queries;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

public class ListProductsCommand : IRequest<PaginatedList<ListProductsResult>>
{
    public QueryOptions Options { get; set; } = new();
}
