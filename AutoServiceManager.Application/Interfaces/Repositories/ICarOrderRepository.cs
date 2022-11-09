using AutoServiceManager.Domain.Entities.Reception;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Interfaces.Repositories
{
    public interface ICarOrderRepository
    {
        IQueryable<CarOrder> CarOrders { get; }

        Task<List<CarOrder>> GetListAsync();

        Task<CarOrder> GetByIdAsync(int carOrderId);

        Task<int> InsertAsync(CarOrder carOrder);

        Task UpdateAsync(CarOrder carOrder);

        Task DeleteAsync(CarOrder carOrder);
    }
}