using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<DeleteProductResult, Product>().ReverseMap();
        CreateMap<RatingResult, Rating>().ReverseMap();
    }
}
