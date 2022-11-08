using CarDealer.Models.Enum;

namespace CarDealer.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Seats { get; set; } = 0;
        public int Year { get; set; } = 0;
        public int Hp { get; set; } = 0;
        public CarType CarType { get; set; } = CarType.Coupe;
        public int CarManufacturerId { get; set; }
        public virtual CarManufacturer CarMake { get; set; }
    }
}
