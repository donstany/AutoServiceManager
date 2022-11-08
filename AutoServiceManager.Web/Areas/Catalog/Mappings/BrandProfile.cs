using AutoServiceManager.Application.Features.Brands.Commands.Create;
using AutoServiceManager.Application.Features.Brands.Commands.Update;
using AutoServiceManager.Application.Features.Brands.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Brands.Queries.GetById;
using AutoServiceManager.Web.Areas.Catalog.Models;
using AutoMapper;

namespace AutoServiceManager.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}