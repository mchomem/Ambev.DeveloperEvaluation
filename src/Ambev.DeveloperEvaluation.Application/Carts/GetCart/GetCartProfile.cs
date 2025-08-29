using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        var dateFormatPtBr = "dd/MM/yyyy";

        CreateMap<GetCartResult, Cart>()
            .ForMember(cart => cart.Date, opt => opt.MapFrom(createCartResult => DateTimeOffset.ParseExact(createCartResult.Date, dateFormatPtBr, CultureInfo.InvariantCulture)));

        CreateMap<Cart, GetCartResult>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString(dateFormatPtBr)))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.CartItens));

        CreateMap<ProductCommand, CartItem>()
            .ForMember(cartItem => cartItem.ProductId, opt => opt.MapFrom(productCommand => productCommand.ProductId))
            .ForMember(cartItem => cartItem.Quantity, opt => opt.MapFrom(productCommand => productCommand.Quantity));

        CreateMap<CartItem, ProductResult>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }
}
