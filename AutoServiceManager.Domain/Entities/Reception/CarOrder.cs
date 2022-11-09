using System;
using AspNetCoreHero.Abstractions.Domain;

namespace AutoServiceManager.Domain.Entities.Reception
{
    public class CarOrder : AuditableEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
