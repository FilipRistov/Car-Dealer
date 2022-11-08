using CarDealer.DataAccess.Abstraction;
using CarDealer.Domain;
using CarDealer.Models;
using CarGarage.DataAccess;

namespace CarDealer.DataAccess.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly DataContext _db;
        public CarRepository(DataContext db)
        {
            _db = db;
        }

        public void Add(Car entity)
        {
            _db.Cars.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Car entity)
        {
             _db.Cars.Remove(entity);
             _db.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return _db.Cars;
        }

        public Car GetById(int id)
        {
            return _db.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Car entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}
