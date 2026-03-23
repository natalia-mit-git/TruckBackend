using Microsoft.EntityFrameworkCore;

namespace TruckBackend.Models
{
    public class TruckContext : DbContext
    {
        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckLoad> TruckLoads { get; set; }
    }
}