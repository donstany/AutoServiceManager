using System;

namespace AutoServiceManager.Application.Features.CarOrders.Queries.GetAllPaged
{
    public class GetAllCarOrdersResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}