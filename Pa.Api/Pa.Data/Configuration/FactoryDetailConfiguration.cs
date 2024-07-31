using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pa.Data.Domain;

namespace Pa.Data.Configuration
{
    public class FactoryDetailConfiguration : IEntityTypeConfiguration<FactoryDetail>
    {
        public void Configure(EntityTypeBuilder<FactoryDetail> builder)
        {
            builder.ToTable("FactoryDetails", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FactoryProfile).HasMaxLength(500);
            builder.Property(x => x.FactoryHistory).HasMaxLength(500);
            builder.Property(x => x.FactoryMission).HasMaxLength(500);
            builder.Property(x => x.FactoryVision).HasMaxLength(500);
            builder.Property(x => x.FactoryValues).HasMaxLength(500);
            builder.Property(x => x.FactoryQualityPolicy).HasMaxLength(500);
            builder.Property(x => x.FactoryCertificates).HasMaxLength(500);
        }
    }
}