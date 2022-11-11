using System;

namespace AutoServiceManager.Application.Features.CarOrders.Queries.GetById
{
    public class GetCarOrderByIdResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CarId { get; set; }
    }
}