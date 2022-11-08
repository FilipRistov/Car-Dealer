using AutoMapper;
using CarDealer.DataAccess.Abstraction;
using CarDealer.Domain.Car;
using CarDealer.Domain.CarManufacturer;
using CarDealer.Exceptions;
using CarDealer.Models;
using CarDealer.Service.Abstraction;

namespace CarDealer.Service.Implementation
{
    public class CarManufacturerService : ICarManufacturerService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CarManufacturer> _carManufacturerRepository;
        public CarManufacturerService(IMapper mapper, IRepository<CarManufacturer> carManufacturerRepository)
        {
            _mapper = mapper;
            _carManufacturerRepository = carManufacturerRepository;
        }
        public List<CarManufacturer> GetAllCarManufacturers()
        {
            return _carManufacturerRepository.GetAll().ToList();
        }
        public CarManufacturer GetCarManufacturerId(int id)
        {
            return _carManufacturerRepository.GetById(id);
        }
        public List<CarManufacturer> AddCarManufacturer(AddCarManufacturer carManufacturer)
        {
            CarManufacturer car_Manufacturer = _mapper.Map<CarManufacturer>(carManufacturer);
            _carManufacturerRepository.Add(car_Manufacturer);
            return _carManufacturerRepository.GetAll().ToList();
        }

        public List<CarManufacturer> DeleteCarManufacturer(int id)
        {
            CarManufacturer carManufacturer = _carManufacturerRepository.GetById(id);
            if (carManufacturer == null)
            {
                throw new CarException(404, id, $"Car Manufacturer with Id : {id} does not exist");
            }
            
            _carManufacturerRepository.Delete(carManufacturer);
            return _carManufacturerRepository.GetAll().ToList();
        }
    }
}
