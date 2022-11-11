using AutoServiceManager.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AutoServiceManager.Application.Features.CarOrders.Commands.Update
{
    public class UpdateCarOrderCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CarId { get; set; }

        public class UpdateCarOrderCommandHandler : IRequestHandler<UpdateCarOrderCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICarOrderRepository _carOrderRepository;

            public UpdateCarOrderCommandHandler(ICarOrderRepository carOrderRepository, IUnitOfWork unitOfWork)
            {
                _carOrderRepository = carOrderRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateCarOrderCommand command, CancellationToken cancellationToken)
            {
                var carOrder = await _carOrderRepository.GetByIdAsync(command.Id);

                if (carOrder == null)
                {
                    return Result<int>.Fail($"CarOrder Not Found.");
                }
                else
                {
                    carOrder.Description = command.Description; //mandatory
                    carOrder.CarId = (command.CarId == 0) ? carOrder.CarId : command.CarId; //mandatory
                    carOrder.Date = command.Date ?? DateTime.Now;

                    await _carOrderRepository.UpdateAsync(carOrder);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(carOrder.Id);
                }
            }
        }
    }
}