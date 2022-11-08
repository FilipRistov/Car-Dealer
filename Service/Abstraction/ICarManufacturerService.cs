using CarDealer.Domain.CarManufacturer;
using CarDealer.Models;

namespace CarDealer.Service.Abstraction
{
    public interface ICarManufacturerService
    {
        List<CarManufacturer> GetAllCarManufacturers();
        List<CarManufacturer> AddCarManufacturer(AddCarManufacturer carManufacturer);
        CarManufacturer GetCarManufacturerId(int id);
        List<CarManufacturer> DeleteCarManufacturer(int id);
    }
}
