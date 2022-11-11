using AutoServiceManager.Application.Extensions;
using AutoServiceManager.Application.Interfaces.Repositories;
using AutoServiceManager.Domain.Entities.Reception;
using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Features.CarOrders.Queries.GetAllPaged
{
    public class GetAllCarOrdersQuery : IRequest<PaginatedResult<GetAllCarOrdersResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllCarOrdersQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllCarOrdersQueryHandler : IRequestHandler<GetAllCarOrdersQuery, PaginatedResult<GetAllCarOrdersResponse>>
    {
        private readonly ICarOrderRepository _repository;

        public GetAllCarOrdersQueryHandler(ICarOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllCarOrdersResponse>> Handle(GetAllCarOrdersQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<CarOrder, GetAllCarOrdersResponse>> expression = e => new GetAllCarOrdersResponse
            {
                Id = e.Id,
                Date = e.Date,
                Description = e.Description,
            };
            var paginatedList = await _repository.CarOrders
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}