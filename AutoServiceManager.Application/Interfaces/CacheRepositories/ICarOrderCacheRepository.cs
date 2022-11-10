using AutoServiceManager.Domain.Entities.Reception;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Interfaces.CacheRepositories
{
    public interface ICarOrderCacheRepository
    {
        Task<List<CarOrder>> GetCachedListAsync();

        Task<CarOrder> GetByIdAsync(int brandId);
    }
}