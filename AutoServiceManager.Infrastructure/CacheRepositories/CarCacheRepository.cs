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
    public class CarCacheRepository : ICarCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICarRepository _carRepository;

        public CarCacheRepository(IDistributedCache distributedCache, ICarRepository carRepository)
        {
            _distributedCache = distributedCache;
            _carRepository = carRepository;
        }

        public async Task<Car> GetByIdAsync(int carId)
        {
            string cacheKey = CarCacheKeys.GetKey(carId);
            var car = await _distributedCache.GetAsync<Car>(cacheKey);
            if (car == null)
            {
                car = await _carRepository.GetByIdAsync(carId);
                Throw.Exception.IfNull(car, "Car", "No Car Found");
                await _distributedCache.SetAsync(cacheKey, car);
            }
            return car;
        }

        public async Task<List<Car>> GetCachedListAsync()
        {
            string cacheKey = CarCacheKeys.ListKey;
            var carList = await _distributedCache.GetAsync<List<Car>>(cacheKey);
            if (carList == null)
            {
                carList = await _carRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, carList);
            }
            return carList;
        }
    }
}
