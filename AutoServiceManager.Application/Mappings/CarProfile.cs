using AutoServiceManager.Application.Features.Brands.Commands.Create;
using AutoServiceManager.Application.Features.Brands.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Brands.Queries.GetById;
using AutoServiceManager.Domain.Entities.Catalog;
using AutoMapper;
using AutoServiceManager.Domain.Entities.Reception;
using AutoServiceManager.Application.Features.Cars.Commands.Create;
using AutoServiceManager.Application.Features.Cars.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Cars.Queries.GetById;

namespace AutoServiceManager.Application.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarCommand, Car>().ReverseMap();
            CreateMap<GetCarByIdResponse, Car>().ReverseMap();
            CreateMap<GetAllCarsCachedResponse, Car>().ReverseMap();
        }
    }
}
