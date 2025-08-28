using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>().ReverseMap();
        CreateMap<CreateProductResult, CreateProductResponse>().ReverseMap();
        
        CreateMap<RatingRequest, RatingCommand>().ReverseMap();
        CreateMap<RatingResult, RatingResponse>().ReverseMap();
    }
}
