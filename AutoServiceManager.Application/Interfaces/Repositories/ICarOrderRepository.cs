using AutoServiceManager.Domain.Entities.Reception;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Interfaces.Repositories
{
    public interface ICarOrderRepository
    {
        IQueryable<CarOrder> CarOrders { get; }

        Task<List<CarOrder>> GetListAsync(string roleName, string userId);

        Task<CarOrder> GetByIdAsync(int carOrderId, string roleName, string userId);

        Task<int> InsertAsync(CarOrder carOrder, string roleName, string userId);

        Task UpdateAsync(CarOrder carOrder, string roleName, string userId);

        Task DeleteAsync(CarOrder carOrder, string roleName, string userId);
    }
}