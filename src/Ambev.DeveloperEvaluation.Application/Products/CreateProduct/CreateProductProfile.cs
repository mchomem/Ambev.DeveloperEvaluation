using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        CreateMap<CreateProductResult, Product>().ReverseMap();

        CreateMap<RatingCommand, Rating>().ReverseMap();
        CreateMap<RatingResult, Rating>().ReverseMap();
    }
}
