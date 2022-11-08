﻿using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoServiceManager.Application.Interfaces.Repositories;
using MediatR;

namespace AutoServiceManager.Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }

        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICarRepository _carRepository;

            public UpdateCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
            {
                _carRepository = carRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
            {
                var car = await _carRepository.GetByIdAsync(command.Id);

                if (car == null)
                {
                    //TODO: Stan
                    //NTH: add in string interpolation placeholder for invoked command
                    return Result<int>.Fail($"Car Not Found.");
                }
                else
                {
                    car.Make = command.Make ?? car.Make;//TODO: null chheck coalesce is not needed it ia mandatory 
                    car.Plate = command.Plate ?? car.Plate;
                    car.Color = command.Color ?? car.Color; //TODO: null chheck coalesce is not needed it ia mandatory 

                    await _carRepository.UpdateAsync(car);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(car.Id);
                }
            }
        }
    }
}
