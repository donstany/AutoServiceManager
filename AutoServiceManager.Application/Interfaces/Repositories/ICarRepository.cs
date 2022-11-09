using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoServiceManager.Domain.Entities.Reception;

namespace AutoServiceManager.Application.Interfaces.Repositories
{
    public interface ICarRepository
    {
        IQueryable<Car> Cars { get; }

        Task<List<Car>> GetListAsync();

        Task<Car> GetByIdAsync(int carId);

        Task<int> InsertAsync(Car car);

        Task UpdateAsync(Car car);

        Task DeleteAsync(Car car);
    }
}
