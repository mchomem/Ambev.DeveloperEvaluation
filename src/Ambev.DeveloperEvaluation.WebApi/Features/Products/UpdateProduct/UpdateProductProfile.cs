using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// AutoMapper profile for UpdateProduct feature
/// </summary>
public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>().ReverseMap();
        CreateMap<UpdateProductResult, UpdateProductResponse>().ReverseMap();

        CreateMap<RatingRequest, RatingCommand>().ReverseMap();
        CreateMap<RatingResult, RatingResponse>().ReverseMap();
    }
}