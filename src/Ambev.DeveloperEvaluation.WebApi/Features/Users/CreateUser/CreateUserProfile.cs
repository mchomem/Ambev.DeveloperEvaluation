using Ambev.DeveloperEvaluation.Application.Users.Common;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>().ReverseMap();
        CreateMap<CreateUserResult, CreateUserResponse>().ReverseMap();

        CreateMap<NameRequest, NameCommand>().ReverseMap();
        CreateMap<AddressRequest, AddressCommand>().ReverseMap();
        CreateMap<GeolocationRequest, GeolocationCommand>().ReverseMap();

        CreateMap<NameResult, NameResponse>().ReverseMap();
        CreateMap<AddressResult, AddressResponse>().ReverseMap();
        CreateMap<GeolocationResult, GeolocationResponse>().ReverseMap();
    }
}
