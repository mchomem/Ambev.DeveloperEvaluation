using Ambev.DeveloperEvaluation.Application.Users.ListUsers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

public class ListUsersProfile : Profile
{
    public ListUsersProfile()
    {
        CreateMap<ListUsersRequest, ListUsersCommand>()
            .ForMember(d => d.Options, o => o.MapFrom(s => new Application.Common.Queries.QueryOptions
            {
                Page = s.Page,
                Size = s.Size,
                Order = s.Order
            }));
        // Result -> Response é direto no Controller via PaginatedResponse.FromPaginatedList
    }
}
