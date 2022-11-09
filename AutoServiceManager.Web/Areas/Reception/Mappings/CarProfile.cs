using AutoMapper;
using AutoServiceManager.Application.Features.Cars.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Cars.Queries.GetById;
using AutoServiceManager.Application.Features.Cars.Commands.Create;
using AutoServiceManager.Application.Features.Cars.Commands.Update;
using AutoServiceManager.Web.Areas.Reception.Models;

namespace AutoServiceManager.Web.Areas.Reception.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<GetAllCarsCachedResponse, CarViewModel>().ReverseMap();
            CreateMap<GetCarByIdResponse, CarViewModel>().ReverseMap();
            CreateMap<CreateCarCommand, CarViewModel>().ReverseMap();
            CreateMap<UpdateCarCommand, CarViewModel>().ReverseMap();
        }
    }
}