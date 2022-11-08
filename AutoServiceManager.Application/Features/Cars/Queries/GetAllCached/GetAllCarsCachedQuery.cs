using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using AutoServiceManager.Application.Interfaces.CacheRepositories;
using MediatR;

namespace AutoServiceManager.Application.Features.Cars.Queries.GetAllCached
{
    public class GetAllCarsCachedQuery : IRequest<Result<List<GetAllCarsCachedResponse>>>
    {
        public GetAllCarsCachedQuery()
        {
        }

        public class GetAllCarsCachedQueryHandler : IRequestHandler<GetAllCarsCachedQuery, Result<List<GetAllCarsCachedResponse>>>
        {
            private readonly ICarCacheRepository _carCacheRepository;
            private readonly IMapper _mapper;

            public GetAllCarsCachedQueryHandler(ICarCacheRepository carCacheRepository, IMapper mapper)
            {
                _carCacheRepository = carCacheRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetAllCarsCachedResponse>>> Handle(GetAllCarsCachedQuery request, CancellationToken cancellationToken)
            {
                var carList = await _carCacheRepository.GetCachedListAsync();
                var mappedCars = _mapper.Map<List<GetAllCarsCachedResponse>>(carList);
                return Result<List<GetAllCarsCachedResponse>>.Success(mappedCars);
            }
        }
    }
}
