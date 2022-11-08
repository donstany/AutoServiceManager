using AutoServiceManager.Infrastructure.Identity.Models;
using AutoServiceManager.Web.Areas.Admin.Models;
using AutoMapper;

namespace AutoServiceManager.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}