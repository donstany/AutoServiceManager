using System;

namespace AutoServiceManager.Application.Features.CarOrdersView.Queries.GetAllCached
{
    public class GetAllCarOrdersReportViewCachedResponse
    {
        public int CarOrderId { get; set; }
        public DateTime CarOrderDate { get; set; }
        public string CarData { get; set; }
        public string CarOrderDescription { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
    }
}