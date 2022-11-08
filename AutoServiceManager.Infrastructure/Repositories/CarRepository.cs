using AutoServiceManager.Application.Interfaces.Repositories;
using AutoServiceManager.Domain.Entities.Reception;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServiceManager.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IRepositoryAsync<Car> _repository;
        private readonly IDistributedCache _distributedCache;

        public CarRepository(IDistributedCache distributedCache, IRepositoryAsync<Car> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Car> Cars => _repository.Entities;

        public async Task DeleteAsync(Car car)
        {
            await _repository.DeleteAsync(car);
            await _distributedCache.RemoveAsync(CacheKeys.CarCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.CarCacheKeys.GetKey(car.Id));
        }

        public async Task<Car> GetByIdAsync(int carId)
        {
            return await _repository.Entities.Where(p => p.Id == carId).FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Car car)
        {
            await _repository.AddAsync(car);
            await _distributedCache.RemoveAsync(CacheKeys.CarCacheKeys.ListKey);
            return car.Id;
        }

        public async Task UpdateAsync(Car car)
        {
            await _repository.UpdateAsync(car);
            await _distributedCache.RemoveAsync(CacheKeys.CarCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.CarCacheKeys.GetKey(car.Id));
        }
    }
}
