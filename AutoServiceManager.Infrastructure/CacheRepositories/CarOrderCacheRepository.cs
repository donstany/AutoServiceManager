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

        public async Task<CarOrder> GetByIdAsync(int carOrderId, string roleName, string userId)
        {
            string cacheKey = CarOrderCacheKeys.GetKey(carOrderId, roleName, userId);
            var carOrder = await _distributedCache.GetAsync<CarOrder>(cacheKey);
            if (carOrder == null)
            {
                carOrder = await _carOrderRepository.GetByIdAsync(carOrderId, roleName, userId);
                Throw.Exception.IfNull(carOrder, "CarOrder", "No CarOrder Found");
                await _distributedCache.SetAsync(cacheKey, carOrder);
            }
            return carOrder;
        }

        public async Task<List<CarOrder>> GetCachedListAsync(string userId, string roleName)
        {
            string cacheKey = CarOrderCacheKeys.GetListKey(roleName, userId);
            var carOrderList = await _distributedCache.GetAsync<List<CarOrder>>(cacheKey);
            if (carOrderList == null)
            {
                carOrderList = await _carOrderRepository.GetListAsync(roleName, userId);
                await _distributedCache.SetAsync(cacheKey, carOrderList);
            }
            return carOrderList;
        }
    }
}