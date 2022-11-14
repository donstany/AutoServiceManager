using AutoServiceManager.Application.Interfaces.Repositories;
using AutoServiceManager.Domain.Entities.Reception;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServiceManager.Infrastructure.Repositories
{
    public class CarOrdersReportViewRepository : ICarOrdersReportViewRepository
    {
        private readonly IRepositoryAsync<CarOrdersReportView> _repository;

        public CarOrdersReportViewRepository(IRepositoryAsync<CarOrdersReportView> repository)
        {
            _repository = repository;
        }

        public async Task<List<CarOrdersReportView>> GetListAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
