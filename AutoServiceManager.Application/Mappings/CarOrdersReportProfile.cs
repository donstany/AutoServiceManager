using AutoMapper;
using AutoServiceManager.Domain.Entities.Reception;
using AutoServiceManager.Application.Features.CarOrdersView.Queries.GetAllCached;

namespace AutoServiceManager.Application.Mappings
{
    internal class CarOrdersReportViewProfile : Profile
    {
        public CarOrdersReportViewProfile()
        {
            CreateMap<GetAllCarOrdersReportViewCachedResponse, CarOrder>().ReverseMap();
        }
    }
}