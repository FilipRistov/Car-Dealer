using CarDealer.DataAccess.Abstraction;
using CarDealer.Models;
using CarGarage.DataAccess;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Prng;

namespace CarDealer.DataAccess.Repositories
{
    public class CarManufacturerRepository : IRepository<CarManufacturer>
    {
        private readonly DataContext _db;

        public CarManufacturerRepository(DataContext db)
        {
            _db = db;
        }

        public void Add(CarManufacturer entity)
        {
            _db.CarManufacturers.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(CarManufacturer entity)
        {
            _db.CarManufacturers.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<CarManufacturer> GetAll()
        {
            return _db.CarManufacturers.Include(c => c.Cars);
        }

        public CarManufacturer GetById(int id)
        {
            return _db.CarManufacturers.Include(c => c.Cars).FirstOrDefault(x => x.Id == id);
        }

        public void Update(CarManufacturer entity)
        {
            throw new Exception();
        }
    }
}
