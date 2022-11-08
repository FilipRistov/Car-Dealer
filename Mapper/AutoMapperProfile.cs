using AutoMapper;
using CarDealer.Domain.Car;
using CarDealer.Domain.CarManufacturer;
using CarDealer.Models;

namespace CarDealer.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, GetCarDto>();
            CreateMap<AddCarDto, Car>();
            CreateMap<GetCarDto, Car>();
            CreateMap<AddCarManufacturer, CarManufacturer>();
        }
    }
}
