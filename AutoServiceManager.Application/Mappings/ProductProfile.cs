using AutoServiceManager.Application.Features.Products.Commands.Create;
using AutoServiceManager.Application.Features.Products.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Products.Queries.GetAllPaged;
using AutoServiceManager.Application.Features.Products.Queries.GetById;
using AutoServiceManager.Domain.Entities.Catalog;
using AutoMapper;

namespace AutoServiceManager.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}