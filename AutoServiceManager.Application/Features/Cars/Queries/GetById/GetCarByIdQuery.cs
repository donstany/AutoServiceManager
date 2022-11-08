using AutoServiceManager.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Features.Cars.Queries.GetById
{
    public class GetCarByIdQuery : IRequest<Result<GetCarByIdResponse>>
    {
        public int Id { get; set; }

        public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Result<GetCarByIdResponse>>
        {
            private readonly ICarCacheRepository _carCacheRepository;
            private readonly IMapper _mapper;

            public GetCarByIdQueryHandler(ICarCacheRepository carCacheRepository, IMapper mapper)
            {
                _carCacheRepository = carCacheRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetCarByIdResponse>> Handle(GetCarByIdQuery query, CancellationToken cancellationToken)
            {
                var car = await _carCacheRepository.GetByIdAsync(query.Id);
                var mappedProduct = _mapper.Map<GetCarByIdResponse>(car);
                return Result<GetCarByIdResponse>.Success(mappedProduct);
            }
        }
    }
}
