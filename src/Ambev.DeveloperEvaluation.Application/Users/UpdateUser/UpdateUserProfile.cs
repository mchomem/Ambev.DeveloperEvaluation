using Ambev.DeveloperEvaluation.Application.Users.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

public class UpdateUserProfile : Profile
{
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserCommand, User>().ReverseMap();
        CreateMap<UpdateUserResult, User>().ReverseMap();

        CreateMap<NameCommand, Name>().ReverseMap();
        CreateMap<NameResult, Name>().ReverseMap();

        CreateMap<AddressCommand, Address>().ReverseMap();
        CreateMap<AddressResult, Address>().ReverseMap();

        CreateMap<GeolocationCommand, Geolocation>().ReverseMap();
        CreateMap<GeolocationResult, Geolocation>().ReverseMap();
    }
}
