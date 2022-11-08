using CarDealer.Domain.Car;
using CarDealer.Models;

namespace CarDealer.Service.Abstraction
{
    public interface ICarService
    {
        List<GetCarDto> GetAll();
        List<GetCarDto> AddCar(AddCarDto car);
        GetCarDto GetCarById(int id);
        GetCarDto UpdateCar(GetCarDto updateCar);
        List<GetCarDto> DeleteCar(int id);


    }
}
