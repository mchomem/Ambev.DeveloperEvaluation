using Ambev.DeveloperEvaluation.Application.Common.Extensions;
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

        // Aplica filtros para campos de string que podem conter asteriscos
        foreach (var filter in request.Options.Filters)
        {
            if (filter.Value.Contains("*"))
            {
                query = query.ApplyFilterString(filter.Key, filter.Value);
                continue;
            }

            // Trata especificamente filtros de data para garantir UTC
            if (filter.Key.EndsWith("CreatedAt") || filter.Key.EndsWith("UpdatedAt"))
            {
                if (DateTime.TryParse(filter.Value, out DateTime dateValue))
                {
                    // Converte para UTC se não for
                    var utcDate = dateValue.Kind == DateTimeKind.Unspecified 
                        ? DateTime.SpecifyKind(dateValue, DateTimeKind.Utc)
                        : dateValue.ToUniversalTime();

                    query = query.ApplyFilters(new Dictionary<string, string> 
                    { 
                        { filter.Key, utcDate.ToString("O") } // Format "O" garante formato ISO 8601
                    });
                    continue;
                }
            }

            // Mantém o comportamento existente para outros tipos de filtros
            query = query.ApplyFilters(new Dictionary<string, string> { { filter.Key, filter.Value } });
        }

        query = query.ApplyOrdering(request.Options.Order);

        var pageEntity = await PaginatedList<User>.CreateAsync(query, request.Options.Page, request.Options.Size);
        var items = _mapper.Map<List<ListUsersResult>>(pageEntity);

        return new PaginatedList<ListUsersResult>(items, pageEntity.TotalCount, pageEntity.CurrentPage, pageEntity.PageSize);
    }
}
