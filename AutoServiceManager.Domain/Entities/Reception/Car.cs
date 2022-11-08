using AspNetCoreHero.Abstractions.Domain;

namespace AutoServiceManager.Domain.Entities.Reception
{
    public class Car : AuditableEntity
    {
        public string Make { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
    }
}
