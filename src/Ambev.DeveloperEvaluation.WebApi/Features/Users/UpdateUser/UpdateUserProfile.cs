using Ambev.DeveloperEvaluation.Application.Users.Common;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserProfile : Profile
{
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserRequest, UpdateUserCommand>().ReverseMap();
        CreateMap<UpdateUserResult, UpdateUserResponse>().ReverseMap();

        CreateMap<NameRequest, NameCommand>().ReverseMap();
        CreateMap<AddressRequest, AddressCommand>().ReverseMap();
        CreateMap<GeolocationRequest, GeolocationCommand>().ReverseMap();

        CreateMap<NameResult, NameResponse>().ReverseMap();
        CreateMap<AddressResult, AddressResponse>().ReverseMap();
        CreateMap<GeolocationResult, GeolocationResponse>().ReverseMap();
    }
}
