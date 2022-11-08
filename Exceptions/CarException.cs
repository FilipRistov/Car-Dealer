namespace CarDealer.Exceptions
{
    public class CarException : Exception
    {

        public int? CarId { get; set; }
        public string? CarMake { get; set; }
        public int StatusCode { get; set; }

        public CarException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public CarException(int? carId, int statusCode, string message) : base(message)
        {
            CarId = carId;
            StatusCode = statusCode;
        }
        public CarException(string? carMake, int statusCode, string message) : base(message)
        {
            CarMake = carMake;
            StatusCode = statusCode;
        }

    }
}
