using AutoServiceManager.Application.Interfaces.CacheRepositories;
using AutoServiceManager.Application.Interfaces.Repositories;
using AutoServiceManager.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoServiceManager.Domain.Entities.Reception;

namespace AutoServiceManager.Infrastructure.CacheRepositories
{
    public class CarOrderCacheRepository : ICarOrderCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICarOrderRepository _carOrderRepository;

        public CarOrderCacheRepository(IDistributedCache distributedCache, ICarOrderRepository carOrderRepository)
        {
            _distributedCache = distributedCache;
            _carOrderRepository = carOrderRepository;
        }

        public async Task<CarOrder> GetByIdAsync(int carOrderId)
        {
            string cacheKey = CarOrderCacheKeys.GetKey(carOrderId);
            var carOrder = await _distributedCache.GetAsync<CarOrder>(cacheKey);
            if (carOrder == null)
            {
                carOrder = await _carOrderRepository.GetByIdAsync(carOrderId);
                Throw.Exception.IfNull(carOrder, "CarOrder", "No CarOrder Found");
                await _distributedCache.SetAsync(cacheKey, carOrder);
            }
            return carOrder;
        }

        public async Task<List<CarOrder>> GetCachedListAsync()
        {
            string cacheKey = CarOrderCacheKeys.ListKey;
            var carOrderList = await _distributedCache.GetAsync<List<CarOrder>>(cacheKey);
            if (carOrderList == null)
            {
                carOrderList = await _carOrderRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, carOrderList);
            }
            return carOrderList;
        }
    }
}