using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<Guid, GetCartCommand>()
            .ConstructUsing(id => new GetCartCommand(id));

        CreateMap<GetCartRequest, GetCartCommand>().ReverseMap();
        CreateMap<GetCartResult, GetCartResponse>().ReverseMap();

        CreateMap<ProductRequest, ProductCommand>().ReverseMap();
        CreateMap<ProductResult, ProductResponse>().ReverseMap();
    }
}
