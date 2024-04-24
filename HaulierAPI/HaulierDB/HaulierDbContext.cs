using Microsoft.EntityFrameworkCore;
using SharedData.Models;

namespace TMS_managerAPI.DB
{
    public class HaulierDbContext : DbContext
    {
        public HaulierDbContext(DbContextOptions<HaulierDbContext> options) : base(options)
        {
        }
        public DbSet<Haulier> Hauliers { get; set; }


    }
}
