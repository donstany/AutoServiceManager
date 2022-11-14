using System.Collections.Generic;
using System.Threading.Tasks;
using AutoServiceManager.Domain.Entities.Reception;

namespace AutoServiceManager.Infrastructure.Repositories
{
    public interface ICarOrdersReportViewRepository
    {
        Task<List<CarOrdersReportView>> GetListAsync();
    }
}
