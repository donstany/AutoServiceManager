using AutoServiceManager.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached
{
    public class GetAllCarOrdersCachedQuery : IRequest<Result<List<GetAllCarOrdersCachedResponse>>>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public GetAllCarOrdersCachedQuery()
        {
        }
    }

    public class GetAllCarOrdersCachedQueryHandler : IRequestHandler<GetAllCarOrdersCachedQuery, Result<List<GetAllCarOrdersCachedResponse>>>
    {
        private readonly ICarOrderCacheRepository _carOrderCacheRepository;
        private readonly IMapper _mapper;

        public GetAllCarOrdersCachedQueryHandler(ICarOrderCacheRepository carOrderCacheRepository, IMapper mapper)
        {
            _carOrderCacheRepository = carOrderCacheRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCarOrdersCachedResponse>>> Handle(GetAllCarOrdersCachedQuery request, CancellationToken cancellationToken)
        {
            var carOrderList = await _carOrderCacheRepository.GetCachedListAsync(request.UserId, request.RoleName);
            var mappedCarOrders = _mapper.Map<List<GetAllCarOrdersCachedResponse>>(carOrderList);
            return Result<List<GetAllCarOrdersCachedResponse>>.Success(mappedCarOrders);
        }
    }
}