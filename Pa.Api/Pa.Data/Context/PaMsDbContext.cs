using Microsoft.EntityFrameworkCore;
using Pa.Data.Configuration;
using Pa.Data.Domain;

namespace Pa.Data.Context
{
    public class PaMsDbContext : DbContext
    {
        public PaMsDbContext(DbContextOptions<PaMsDbContext> options) : base(options)
        {

        }

        public DbSet<Factory> Factories { get; set; }
        public DbSet<FactoryDetail> FactoryDetails { get; set; }
        public DbSet<FactoryLocation> FactoryLocations { get; set; }
        public DbSet<FactoryPhone> FactoryPhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FactoryConfiguration());
            modelBuilder.ApplyConfiguration(new FactoryDetailConfiguration());
            modelBuilder.ApplyConfiguration(new FactoryLocationConfiguration());
            modelBuilder.ApplyConfiguration(new FactoryPhoneConfiguration());
        }
    }
}
