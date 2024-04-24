using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedData.Models;


namespace TMS_managerAPI.DB
{
    public class DriverDbContext : DbContext
    {
        public DriverDbContext(DbContextOptions<DriverDbContext> options) : base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }


    }
}
