using AutoServiceManager.Application.Interfaces.Repositories;
using AutoServiceManager.Domain.Entities.Reception;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServiceManager.Infrastructure.Repositories
{
    public class CarOrderRepository : ICarOrderRepository
    {
        private readonly IRepositoryAsync<CarOrder> _repository;
        private readonly IDistributedCache _distributedCache;

        public CarOrderRepository(IDistributedCache distributedCache, IRepositoryAsync<CarOrder> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<CarOrder> CarOrders => _repository.Entities;

        public async Task DeleteAsync(CarOrder carOrder)
        {
            await _repository.DeleteAsync(carOrder);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.GetKey(carOrder.Id));
        }

        public async Task<CarOrder> GetByIdAsync(int carOrderId)
        {
            return await _repository.Entities.Where(p => p.Id == carOrderId).FirstOrDefaultAsync();
        }

        public async Task<List<CarOrder>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(CarOrder carOrder)
        {
            await _repository.AddAsync(carOrder);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.ListKey);
            return carOrder.Id;
        }

        public async Task UpdateAsync(CarOrder carOrder)
        {
            await _repository.UpdateAsync(carOrder);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.GetKey(carOrder.Id));
        }
    }
}
