using Ambev.DeveloperEvaluation.Application.Common.Pagination;
using Ambev.DeveloperEvaluation.Application.Common.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public class ListUsersHandler : IRequestHandler<ListUsersCommand, PaginatedList<ListUsersResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ListUsersHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ListUsersResult>> Handle(ListUsersCommand request, CancellationToken ct)
    {
        var query = _userRepository.GetAll();

        query = query
            .ApplyFilters(request.Options.Filters)
            .ApplyOrdering(request.Options.Order);

        // pagina sobre a entidade para que o Count() seja correto
        var pageEntity = await PaginatedList<User>.CreateAsync(query, request.Options.Page, request.Options.Size);

        // mapeia somente os itens (manter metadados)
        var items = _mapper.Map<List<ListUsersResult>>(pageEntity);

        return new PaginatedList<ListUsersResult>(items, pageEntity.TotalCount, pageEntity.CurrentPage, pageEntity.PageSize);
    }
}
