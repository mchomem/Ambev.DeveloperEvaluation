using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductsProfile : Profile
{
    public ListProductsProfile()
    {
        //CreateMap<ListProductsRequest, ListProductsCommand>()
        //    .ForPath(dest => dest.Options.Page, opt => opt.MapFrom(src => src.Page))
        //    .ForPath(dest => dest.Options.Size, opt => opt.MapFrom(src => src.Size))
        //    .ForPath(dest => dest.Options.Order, opt => opt.MapFrom(src => src.Order));

        CreateMap<ListProductsRequest, ListProductsCommand>()
            .ForMember(d => d.Options, o => o.MapFrom(s => new Application.Common.Queries.QueryOptions
            {
                Page = s.Page,
                Size = s.Size,
                Order = s.Order
            }));
    }
}