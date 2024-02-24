using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class StatusSchedulingEntityTypeConfiguration : IEntityTypeConfiguration<StatusSchedulingEntity>
{
    public void Configure(EntityTypeBuilder<StatusSchedulingEntity> builder)
    {
        builder.ToTable("TB_SCHEDULING_STATUS");

        builder.Property(f => f.Name)
        .HasColumnName("TXT_NAME")
        .IsRequired();

        builder.Property(f => f.Status)
       .HasColumnName("COD_STATUS");

        builder.HasQueryFilter(x => !x.IsDeleted);
        //builder.HasIndex(f => f.RegisterNumber).IsUnique();
    }
}
