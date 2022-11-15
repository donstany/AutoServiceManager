using AutoMapper;
using AutoServiceManager.Domain.Entities.Reception;
using AutoServiceManager.Application.Features.CarOrdersView.Queries.GetAllCached;

namespace AutoServiceManager.Application.Mappings
{
    public class CarOrdersReportViewProfile : Profile
    {
        public CarOrdersReportViewProfile()
        {
            CreateMap<GetAllCarOrdersReportViewCachedResponse, CarOrdersReportView>().ReverseMap();
        }
    }
}