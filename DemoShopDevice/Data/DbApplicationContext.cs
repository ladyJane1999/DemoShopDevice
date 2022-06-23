using Microsoft.EntityFrameworkCore;
using ProjectDemo.Model;
using SiteShopCar.Model;

namespace SiteShopCar.Data
{
    public class DbApplicationContext : DbContext
    {
      
        public DbSet<Device> Devices { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<TypeDevice> TypeDevices { get; set; }
      
        public DbSet<Rating> Rating { get; set; }
        
        public DbSet<Users> Users { get; set; }

        public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options)
        { }
    }
}
