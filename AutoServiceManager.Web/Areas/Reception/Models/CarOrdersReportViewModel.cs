using System;

namespace AutoServiceManager.Web.Areas.Reception.Models
{
    public class CarOrdersReportViewModel
    {
        public int Id { get; set; }
        public int CarOrderId { get; set; }
        public DateTime CarOrderDate { get; set; }
        public string CarData { get; set; }
        public string CarOrderDescription { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
    }
}
