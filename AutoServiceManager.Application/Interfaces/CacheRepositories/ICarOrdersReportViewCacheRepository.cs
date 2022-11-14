using System.Collections.Generic;
using System.Threading.Tasks;
using AutoServiceManager.Domain.Entities.Reception;

namespace AutoServiceManager.Application.Interfaces.CacheRepositories
{
    
    public interface ICarOrdersReportViewCacheRepository
    {
        Task<List<CarOrdersReportView>> GetCachedListAsync();
    }
}
