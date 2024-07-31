using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pa.Data.Domain;

namespace Pa.Data.Configuration
{
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            builder.ToTable("Factories", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FactoryName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.EmployeeCount).IsRequired();
            builder.Property(x => x.EstablishedDate).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.TaxNumber).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.TaxNumber).IsUnique();

            builder.HasMany(x => x.FactoryLocations).WithOne(x => x.Factory).HasForeignKey(x => x.FactoryId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.FactoryPhones).WithOne(x => x.Factory).HasForeignKey(x => x.FactoryId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.FactoryDetail).WithOne(x => x.Factory).HasForeignKey<FactoryDetail>(x => x.FactoryId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}