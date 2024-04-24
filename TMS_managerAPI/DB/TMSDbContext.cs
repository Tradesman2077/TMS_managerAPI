using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedData.Models;


namespace TMS_managerAPI.DB
{
    public class TMSDbContext : DbContext
    {
        public TMSDbContext(DbContextOptions<TMSDbContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Haulier> Hauliers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Truck)
                .WithMany()
                .HasForeignKey(d => d.TruckId)
                .OnDelete(DeleteBehavior.NoAction); // or other desired behavior

            // Configure other relationships...

            base.OnModelCreating(modelBuilder);

        }
    }
}
