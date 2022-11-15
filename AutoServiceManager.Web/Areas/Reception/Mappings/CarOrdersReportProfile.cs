using AutoServiceManager.Web.Areas.Reception.Models;
using AutoMapper;
using AutoServiceManager.Application.Features.CarOrdersView.Queries.GetAllCached;

namespace AutoServiceManager.Web.Areas.Reception.Mappings
{
    internal class CarOrdersReportViewProfile : Profile
    {
        public CarOrdersReportViewProfile()
        { 
            CreateMap<GetAllCarOrdersReportViewCachedResponse, CarOrdersReportViewModel>().ReverseMap();
        }
    }
}