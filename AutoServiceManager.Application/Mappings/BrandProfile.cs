using AutoServiceManager.Application.Features.Brands.Commands.Create;
using AutoServiceManager.Application.Features.Brands.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Brands.Queries.GetById;
using AutoServiceManager.Domain.Entities.Catalog;
using AutoMapper;

namespace AutoServiceManager.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}