using AutoServiceManager.Application.Enums;
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

        public async Task DeleteAsync(CarOrder carOrder, string roleName, string userId)
        {
            await _repository.DeleteAsync(carOrder);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.GetListKey(roleName, userId));
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.GetKey(carOrder.Id, roleName, userId));
        }

        public async Task<CarOrder> GetByIdAsync(int carOrderId, string roleName, string userId)
        {
            return await _repository.Entities.Where(p => p.Id == carOrderId).FirstOrDefaultAsync();
        }

        public async Task<List<CarOrder>> GetListAsync(string roleName, string userId)
        {
            var query = _repository.Entities.Include(x => x.Car);

            if (roleName == Roles.SuperAdmin.ToString())
            {
                return await query.OrderByDescending(c => c.Id).ToListAsync();
            }

            return await query.Where(c => c.CreatedBy == userId).OrderByDescending(c => c.Id).ToListAsync();
        }

        public async Task<int> InsertAsync(CarOrder carOrder, string roleName, string userId)
        {
            await _repository.AddAsync(carOrder);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.GetListKey(roleName, userId));
            return carOrder.Id;
        }

        public async Task UpdateAsync(CarOrder carOrder, string roleName, string userId)
        {
            await _repository.UpdateAsync(carOrder);
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.GetListKey(roleName, userId));
            await _distributedCache.RemoveAsync(CacheKeys.CarOrderCacheKeys.GetKey(carOrder.Id, roleName, userId));
        }
    }
}
