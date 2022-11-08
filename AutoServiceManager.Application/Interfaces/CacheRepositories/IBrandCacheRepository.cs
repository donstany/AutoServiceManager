using AutoServiceManager.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Interfaces.CacheRepositories
{
    public interface IProductCacheRepository
    {
        Task<List<Product>> GetCachedListAsync();

        Task<Product> GetByIdAsync(int brandId);
    }
}