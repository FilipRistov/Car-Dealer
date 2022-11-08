using CarDealer.DataAccess.Abstraction;
using CarDealer.DataAccess.Repositories;
using CarDealer.Helpers;
using CarDealer.Models;
using CarDealer.Service.Abstraction;
using CarDealer.Service.Implementation;

namespace CarDealer.DependencyInjection
{
    public static class ServicesExtension
    {
        public static IServiceCollection RegisterServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarManufacturerService, CarManufacturerService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtToken, JwtToken>();
            services.AddScoped<IRepository<Car>, CarRepository>();
            services.AddScoped<IRepository<CarManufacturer>, CarManufacturerRepository>();
            return services;
        }
    }
}
