using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, CreatedProductResponse>();

        CreateMap<UpdateProductCommand, Product>();
        CreateMap<Product, UpdatedProductResponse>();

        CreateMap<DeleteProductCommand, Product>();
        CreateMap<Product, DeletedProductResponse>();

        CreateMap<Product, GetByIdProductResponse>();

        CreateMap<Product, GetListProductListItemDto>();
        CreateMap<IPaginate<Product>, GetListResponse<GetListProductListItemDto>>();
    }
}