using CarDealer.Domain.Auth;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarGarage.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().
                HasOne(n => n.CarMake).
                WithMany(x => x.Cars).HasForeignKey(p => p.CarManufacturerId);
        }
    }
}
