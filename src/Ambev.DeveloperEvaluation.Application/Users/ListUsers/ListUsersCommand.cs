using Ambev.DeveloperEvaluation.Application.Common.Pagination;
using Ambev.DeveloperEvaluation.Application.Common.Queries;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public class ListUsersCommand : IRequest<PaginatedList<ListUsersResult>>
{
    public QueryOptions Options { get; set; } = new();
}
