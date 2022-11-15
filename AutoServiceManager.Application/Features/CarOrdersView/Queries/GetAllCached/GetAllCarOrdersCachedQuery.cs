using AutoServiceManager.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoServiceManager.Application.Features.CarOrdersView.Queries.GetAllCached;
using AutoServiceManager.Domain.Entities.Reception;

namespace AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached
{
    public class GetAllCarOrdersReportViewCachedQuery : IRequest<Result<List<GetAllCarOrdersReportViewCachedResponse>>>
    {
        public GetAllCarOrdersReportViewCachedQuery()
        {
        }
    }

    public class GetAllCarOrdersReportViewCachedQueryHandler : IRequestHandler<GetAllCarOrdersReportViewCachedQuery, Result<List<GetAllCarOrdersReportViewCachedResponse>>>
    {
        private readonly ICarOrdersReportViewCacheRepository _carOrdersReportViewCacheRepository;
        private readonly IMapper _mapper;

        public GetAllCarOrdersReportViewCachedQueryHandler(ICarOrdersReportViewCacheRepository carOrdersReportViewCacheRepository, IMapper mapper)
        {
            _carOrdersReportViewCacheRepository = carOrdersReportViewCacheRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCarOrdersReportViewCachedResponse>>> Handle(GetAllCarOrdersReportViewCachedQuery request, CancellationToken cancellationToken)
        {
            List<CarOrdersReportView> carOrdersReportViewList = await _carOrdersReportViewCacheRepository.GetCachedListAsync();
            var mappedCarOrdersReportViews = _mapper.Map<List<GetAllCarOrdersReportViewCachedResponse>>(carOrdersReportViewList);
            return Result<List<GetAllCarOrdersReportViewCachedResponse>>.Success(mappedCarOrdersReportViews);
        }
    }
}