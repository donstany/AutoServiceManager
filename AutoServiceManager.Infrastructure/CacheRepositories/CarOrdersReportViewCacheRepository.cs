using AutoServiceManager.Application.Interfaces.CacheRepositories;
using AutoServiceManager.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoServiceManager.Domain.Entities.Reception;
using AutoServiceManager.Infrastructure.Repositories;

namespace AutoServiceManager.Infrastructure.CacheRepositories
{
    public class CarOrdersReportViewCacheRepository : ICarOrdersReportViewCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICarOrdersReportViewRepository _carOrdersReportViewRepository;

        public CarOrdersReportViewCacheRepository(IDistributedCache distributedCache, ICarOrdersReportViewRepository carOrderRepository)
        {
            _distributedCache = distributedCache;
            _carOrdersReportViewRepository = carOrderRepository;
        }

        public async Task<List<CarOrdersReportView>> GetCachedListAsync()
        {
            string cacheKey = CarOrdersReportViewCacheKeys.ListKey;
            var carOrdersReportViewCacheKeysList = await _distributedCache.GetAsync<List<CarOrdersReportView>>(cacheKey);
            carOrdersReportViewCacheKeysList = null;
            if (carOrdersReportViewCacheKeysList == null)
            {
                carOrdersReportViewCacheKeysList = await _carOrdersReportViewRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, carOrdersReportViewCacheKeysList);
            }
            return carOrdersReportViewCacheKeysList;
        }
    }
}