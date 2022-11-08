using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using AutoServiceManager.Application.Interfaces.Repositories;
using AutoServiceManager.Domain.Entities.Reception;
using MediatR;

namespace AutoServiceManager.Application.Features.Cars.Commands.Create
{
    public partial class CreateCarCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Tax { get; set; }
    }
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<int>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            await _carRepository.InsertAsync(car);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(car.Id);
        }
    }
}
