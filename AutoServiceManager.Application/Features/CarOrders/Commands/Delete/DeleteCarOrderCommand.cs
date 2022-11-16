using AutoServiceManager.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Features.CarOrders.Commands.Delete
{
    public class DeleteCarOrderCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }

        public class DeleteCarOrderCommandHandler : IRequestHandler<DeleteCarOrderCommand, Result<int>>
        {
            private readonly ICarOrderRepository _carOrderRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCarOrderCommandHandler(ICarOrderRepository carOrderRepository, IUnitOfWork unitOfWork)
            {
                _carOrderRepository = carOrderRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteCarOrderCommand command, CancellationToken cancellationToken)
            {
                var carOrder = await _carOrderRepository.GetByIdAsync(command.Id, command.RoleName, command.UserId);
                await _carOrderRepository.DeleteAsync(carOrder, command.RoleName, command.UserId);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(carOrder.Id);
            }
        }
    }
}