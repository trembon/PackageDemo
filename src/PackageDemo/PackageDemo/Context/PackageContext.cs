using Microsoft.EntityFrameworkCore;

namespace PackageDemo.Context
{
    public class PackageContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }

        public PackageContext(DbContextOptions<PackageContext> options) : base(options) { }
    }
}
