using AutoServiceManager.Domain.Entities.Catalog;
using AutoMapper;
using AutoServiceManager.Application.Features.CarOrders.Commands.Create;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetById;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllPaged;

namespace AutoServiceManager.Application.Mappings
{
    internal class CarOrderProfile : Profile
    {
        public CarOrderProfile()
        {
            CreateMap<CreateCarOrderCommand, Product>().ReverseMap();
            CreateMap<GetCarOrderByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllCarOrdersCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllCarOrdersResponse, Product>().ReverseMap();
        }
    }
}