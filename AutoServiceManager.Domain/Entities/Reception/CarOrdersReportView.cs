using System;

namespace AutoServiceManager.Domain.Entities.Reception
{
    public class CarOrdersReportView 
    {
        public int CarOrderId { get; set; }
        public DateTime CarOrderDate { get; set; }
        public string CarData { get; set; }
        public string CarOrderDescription { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
    }
}
