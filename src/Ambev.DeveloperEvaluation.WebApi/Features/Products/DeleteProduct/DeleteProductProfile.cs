﻿using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// Profile for mapping DeleteProduct feature requests to commands
/// </summary>
public class DeleteProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProduct feature
    /// </summary>
    public DeleteProductProfile()
    {
        CreateMap<Guid, DeleteProductCommand>()
            .ConstructUsing(id => new DeleteProductCommand(id));

        CreateMap<DeleteProductResult, DeleteProductResponse>().ReverseMap();
        CreateMap<RatingResult, RatingResponse>().ReverseMap();
    }
}
