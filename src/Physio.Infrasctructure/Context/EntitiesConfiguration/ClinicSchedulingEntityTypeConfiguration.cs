using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class ClinicSchedulingEntityTypeConfiguration : IEntityTypeConfiguration<ClinicSchedulingEntity>
{
    public void Configure(EntityTypeBuilder<ClinicSchedulingEntity> builder)
    {
        builder.ToTable("TB_CLINIC_SCHEDULING");

        builder.Property(f => f.SchedulingId)
        .HasMaxLength(36)
        .HasColumnName("COD_SCHEDULING")
        .IsRequired();

        builder.HasOne(p => p.SchedulingEntity)
       .WithMany()
       .HasForeignKey(p => p.SchedulingId)
       .OnDelete(DeleteBehavior.NoAction);

        builder.Property(f => f.ClinicId)
        .HasColumnName("COD_CLINIC")
        .HasMaxLength(36);

        builder.HasOne(p => p.ClinicEntity)
        .WithMany()
        .HasForeignKey(p => p.ClinicId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
