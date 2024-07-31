using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pa.Data.Domain;

namespace Pa.Data.Configuration
{
    public class FactoryLocationConfiguration : IEntityTypeConfiguration<FactoryLocation>
    {
        public void Configure(EntityTypeBuilder<FactoryLocation> builder)
        {
            builder.ToTable("FactoryLocations", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FactoryId).IsRequired();
            builder.Property(x => x.LocationName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(30).IsRequired();
            builder.Property(x => x.City).HasMaxLength(30).IsRequired();
            builder.Property(x => x.District).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(250).IsRequired();
            builder.Property(x => x.PostalCode).HasMaxLength(6).IsRequired();
        }
    }
}