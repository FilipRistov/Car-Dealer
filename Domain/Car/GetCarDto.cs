
using CarDealer.Models.Enum;

namespace CarDealer.Domain.Car
{
    public class GetCarDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public int Year { get; set; }
        public int Hp { get; set; }
        public CarType CarType { get; set; }
    }
}
