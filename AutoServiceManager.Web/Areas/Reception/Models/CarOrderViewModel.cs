using System;
using AutoServiceManager.Domain.Entities.Reception;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoServiceManager.Web.Areas.Reception.Models
{
    public class CarOrderViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int CarId { get; set; }
        public Car Car { get; set; }
        public SelectList Cars { get; set; }
    }
}
