using AutoServiceManager.Domain.Entities.Catalog;
using AutoMapper;
using AutoServiceManager.Application.Features.CarOrders.Commands.Create;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetById;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllPaged;
using AutoServiceManager.Domain.Entities.Reception;

namespace AutoServiceManager.Application.Mappings
{
    internal class CarOrderProfile : Profile
    {
        public CarOrderProfile()
        {
            CreateMap<CreateCarOrderCommand, CarOrder>().ReverseMap();
            CreateMap<GetCarOrderByIdResponse, CarOrder>().ReverseMap();
            CreateMap<GetAllCarOrdersCachedResponse, CarOrder>().ReverseMap();
            CreateMap<GetAllCarOrdersResponse, CarOrder>().ReverseMap();
        }
    }
}