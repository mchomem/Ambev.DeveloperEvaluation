using Ambev.DeveloperEvaluation.Application.Users.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

public class DeleteUserProfile : Profile
{
    public DeleteUserProfile()
    {
        CreateMap<DeleteUserResult, User>().ReverseMap();
        CreateMap<NameResult, Name>().ReverseMap();
        CreateMap<AddressResult, Address>().ReverseMap();
        CreateMap<GeolocationResult, Geolocation>().ReverseMap();
    }
}
