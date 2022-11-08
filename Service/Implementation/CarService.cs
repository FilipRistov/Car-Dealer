using AutoMapper;
using CarDealer.DataAccess.Abstraction;
using CarDealer.Domain.Car;
using CarDealer.Exceptions;
using CarDealer.Models;
using CarDealer.Service.Abstraction;
using CarGarage.DataAccess;

namespace CarDealer.Service.Implementation
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _db;
        private readonly IRepository<Car> _carRepository;

        public CarService(IMapper mapper, DataContext db, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _db = db;
            _carRepository = carRepository;
        }
        public List<GetCarDto> GetAll()
        {
            return _carRepository.GetAll().
                Select(c => _mapper.Map<GetCarDto>(c)).
                ToList();
        }
        public GetCarDto GetCarById(int id)
        {
            var car = _carRepository.GetById(id);
            if(car == null)
            {
                throw new CarException(404, id, $"Car with Id : {id} does not exist");
            }
            return _mapper.Map<GetCarDto>(car);
        }
        public List<GetCarDto> AddCar(AddCarDto car)
        {           
            Car newCar = _mapper.Map<Car>(car);
            CarManufacturer carMake = _db.CarManufacturers.FirstOrDefault(x => x.Make == car.Make);
            if(carMake == null)
            {
                throw new CarException(car.Make, 404, $"Car manufacturer {car.Make} does not exist");
            }
            newCar.CarManufacturerId = carMake.Id;
            _carRepository.Add(newCar);
            return _carRepository.GetAll().
                Select(c => _mapper.Map<GetCarDto>(c)).
                ToList();
        }

        public List<GetCarDto> DeleteCar(int id)
        {
            var car = _carRepository.GetById(id);
            if(car == null)
            {
                throw new CarException(404, id, $"Car with Id : {id} does not exist");
            }
            _carRepository.Delete(car);
            return _db.Cars.Select(c => _mapper.Map<GetCarDto>(c)).ToList();
        }

        public GetCarDto UpdateCar(GetCarDto updateCar)
        {
            Car car = _carRepository.GetById(updateCar.Id);
            if (car == null)
            {
                throw new CarException(404, updateCar.Id, $"Car with Id : {updateCar.Id} does not exist");
            }
            CarManufacturer carMake = _db.CarManufacturers.FirstOrDefault(x => x.Make == updateCar.Make);
            if (carMake == null)
            {
                throw new CarException(updateCar.Make, 404, $"Car manufacturer {updateCar.Make} does not exist");
            }
            _mapper.Map(updateCar, car);
            car.CarManufacturerId = carMake.Id;
            _carRepository.Update(car);
            return _mapper.Map<GetCarDto>(car);
        }
    }
}
