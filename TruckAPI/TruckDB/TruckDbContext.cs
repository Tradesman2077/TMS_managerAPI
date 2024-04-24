using Microsoft.EntityFrameworkCore;
using SharedData.Models;

namespace TMS_managerAPI.DB
{
    public class TruckDbContext : DbContext
    {
        public TruckDbContext(DbContextOptions<TruckDbContext> options) : base(options)
        {
        }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Haulier> Hauliers { get; set; }
    }
}
