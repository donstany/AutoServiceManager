using AutoServiceManager.Domain.Entities.Reception;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Interfaces.Repositories
{
    public interface ICarOrderRepository
    {
        IQueryable<CarOrder> CarOrders { get; }

        Task<List<CarOrder>> GetListAsync(string userId);

        Task<CarOrder> GetByIdAsync(int carOrderId, string userId);

        Task<int> InsertAsync(CarOrder carOrder, string userId);

        Task UpdateAsync(CarOrder carOrder, string userId);

        Task DeleteAsync(CarOrder carOrder, string userId);
    }
}