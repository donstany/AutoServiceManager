using AutoServiceManager.Application.Features.CarOrders.Commands.Create;
using AutoServiceManager.Application.Features.CarOrders.Commands.Update;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetById;
using AutoServiceManager.Web.Areas.Reception.Models;
using AutoMapper;

namespace AutoServiceManager.Web.Areas.Catalog.Mappings
{
    internal class CarOrderProfile : Profile
    {
        public CarOrderProfile()
        {
            CreateMap<GetAllCarOrdersCachedResponse, CarOrderViewModel>().ReverseMap();
            CreateMap<GetCarOrderByIdResponse, CarOrderViewModel>().ReverseMap();
            CreateMap<CreateCarOrderCommand, CarOrderViewModel>().ReverseMap();
            CreateMap<UpdateCarOrderCommand, CarOrderViewModel>().ReverseMap();
        }
    }
}