using System.Text.Json.Serialization;

namespace CarDealer.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CarType
    {
        Coupe = 1,
        Sedan,
        Wagon,
        Cabriolet,
        HatchBack,
        Suv,
        Truck,
    }
}
