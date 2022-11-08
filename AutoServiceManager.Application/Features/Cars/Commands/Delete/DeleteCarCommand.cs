using AutoServiceManager.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Result<int>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
            {
                _carRepository = carRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
            {
                var car = await _carRepository.GetByIdAsync(command.Id);
                await _carRepository.DeleteAsync(car);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(car.Id);
            }
        }
    }
}
