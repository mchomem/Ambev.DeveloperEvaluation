using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.Common;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<CreateUserResult, User>().ReverseMap();

        CreateMap<NameCommand, Name>().ReverseMap();
        CreateMap<NameResult, Name>().ReverseMap();

        CreateMap<AddressCommand, Address>().ReverseMap(); 
        CreateMap<AddressResult, Address>().ReverseMap();

        CreateMap<GeolocationCommand, Geolocation>().ReverseMap();
        CreateMap<GeolocationResult, Geolocation>().ReverseMap();
    }
}
