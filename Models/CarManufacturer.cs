﻿namespace CarDealer.Models
{
    public class CarManufacturer
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Country { get; set; }
        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
