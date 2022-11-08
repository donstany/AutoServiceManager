namespace AutoServiceManager.Application.Features.Cars.Queries.GetById
{
    public class GetCarByIdResponse
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
    }
}
