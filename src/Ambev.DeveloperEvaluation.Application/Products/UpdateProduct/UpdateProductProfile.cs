using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductCommand, Product>().ReverseMap();
        CreateMap<UpdateProductResult, Product>().ReverseMap();

        CreateMap<RatingCommand, Rating>().ReverseMap();
        CreateMap<RatingResult, Rating>().ReverseMap();
    }
}
