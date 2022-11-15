using AutoServiceManager.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using AutoServiceManager.Domain.Entities.Reception;

namespace AutoServiceManager.Application.Features.CarOrders.Commands.Create
{
    public partial class CreateCarOrderCommand : IRequest<Result<int>>
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
    }

    public class CreateCarOrderCommandHandler : IRequestHandler<CreateCarOrderCommand, Result<int>>
    {
        private readonly ICarOrderRepository _carOrderRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateCarOrderCommandHandler(ICarOrderRepository carOrderRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _carOrderRepository = carOrderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCarOrderCommand request, CancellationToken cancellationToken)
        {
            var carOrder = _mapper.Map<CarOrder>(request);
            await _carOrderRepository.InsertAsync(carOrder, request.UserId);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(carOrder.Id);
        }
    }
}