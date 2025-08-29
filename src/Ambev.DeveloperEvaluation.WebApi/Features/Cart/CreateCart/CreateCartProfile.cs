using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>().ReverseMap();
        CreateMap<CreateCartResult, CreateCartResponse>().ReverseMap();

        CreateMap<ProductRequest, ProductCommand>().ReverseMap();
        CreateMap<ProductResult, ProductResponse>().ReverseMap();
    }
}
