using AutoServiceManager.Domain.Entities.Reception;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Interfaces.CacheRepositories
{
    public interface ICarOrderCacheRepository
    {
        Task<List<CarOrder>> GetCachedListAsync(string userId);

        Task<CarOrder> GetByIdAsync(int brandId, string userId);
    }
}