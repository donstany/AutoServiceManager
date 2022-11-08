using AutoServiceManager.Application.Features.Products.Commands.Create;
using AutoServiceManager.Application.Features.Products.Commands.Update;
using AutoServiceManager.Application.Features.Products.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Products.Queries.GetById;
using AutoServiceManager.Web.Areas.Catalog.Models;
using AutoMapper;

namespace AutoServiceManager.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}