using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pa.Data.Domain;

namespace Pa.Data.Configuration
{
    public class FactoryPhoneConfiguration : IEntityTypeConfiguration<FactoryPhone>
    {
        public void Configure(EntityTypeBuilder<FactoryPhone> builder)
        {
            builder.ToTable("FactoryPhones", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FactoryId).IsRequired();
            builder.Property(x => x.IsPrimary).IsRequired();
            builder.Property(x => x.CountryCode).HasMaxLength(3).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();

            builder.HasIndex(x => new { x.CountryCode, x.PhoneNumber }).IsUnique();
        }
    }
}