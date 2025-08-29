using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.DeleteCart
{
    public class DeleteCartProfile : Profile
    {
        public DeleteCartProfile()
        {
            CreateMap<Guid, DeleteCartCommand>()
            .ConstructUsing(id => new DeleteCartCommand(id));

            CreateMap<DeleteCartRequest, DeleteCartCommand>().ReverseMap();
            CreateMap<DeleteCartResult, DeleteCartResponse>().ReverseMap();

            CreateMap<ProductRequest, ProductCommand>().ReverseMap();
            CreateMap<ProductResult, ProductResponse>().ReverseMap();
        }
    }
}
