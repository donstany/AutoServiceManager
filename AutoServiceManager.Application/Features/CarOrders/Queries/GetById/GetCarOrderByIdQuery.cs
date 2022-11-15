using AutoServiceManager.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Features.CarOrders.Queries.GetById
{
    public class GetCarOrderByIdQuery : IRequest<Result<GetCarOrderByIdResponse>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public class GetCarOrderByByIdQueryHandler : IRequestHandler<GetCarOrderByIdQuery, Result<GetCarOrderByIdResponse>>
        {
            private readonly ICarOrderCacheRepository _carOrderCache;
            private readonly IMapper _mapper;

            public GetCarOrderByByIdQueryHandler(ICarOrderCacheRepository carOrderCache, IMapper mapper)
            {
                _carOrderCache = carOrderCache;
                _mapper = mapper;
            }

            public async Task<Result<GetCarOrderByIdResponse>> Handle(GetCarOrderByIdQuery query, CancellationToken cancellationToken)
            {
                var carOrder = await _carOrderCache.GetByIdAsync(query.Id, query.UserId);
                var mappedCarOrder = _mapper.Map<GetCarOrderByIdResponse>(carOrder);
                return Result<GetCarOrderByIdResponse>.Success(mappedCarOrder);
            }
        }
    }
}