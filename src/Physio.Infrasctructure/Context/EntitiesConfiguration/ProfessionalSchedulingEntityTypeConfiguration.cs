using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class ProfessionalSchedulingEntityTypeConfiguration : IEntityTypeConfiguration<ProfessionalSchedulingEntity>
{
    public void Configure(EntityTypeBuilder<ProfessionalSchedulingEntity> builder)
    {
        builder.ToTable("TB_PROFESSIONAL_SCHEDULING");

        builder.Property(f => f.Date)
        .HasColumnName("DAT_DATE")
        .IsRequired();

        builder.Property(f => f.SchedulingTypeId)
        .HasMaxLength(36)
        .HasColumnName("COD_SCHEDULING_TYPE")
        .IsRequired();

        builder.HasOne(p => p.SchedulingTypeEntity)
       .WithMany()
       .HasForeignKey(p => p.SchedulingTypeId)
       .OnDelete(DeleteBehavior.NoAction);


        builder.Property(f => f.PatientId)
        .HasColumnName("COD_PATIENT")
        .HasMaxLength(36)
        .IsRequired();

        builder.HasOne(p => p.PatientEntity)
        .WithMany()
        .HasForeignKey(p => p.PatientId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(f => f.ProfessionalId)
        .HasColumnName("COD_PROFESSIONAL")
        .HasMaxLength(36)
        .IsRequired();

        builder.HasOne(p => p.ProfessionalEntity)
        .WithMany()
        .HasForeignKey(p => p.ProfessionalId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(f => f.SchedulingStatusId)
        .HasColumnName("COD_SCHEDULING_STATUS")
        .HasMaxLength(36)
        .IsRequired();

        builder.HasOne(p => p.SchedulingStatusEntity)
        .WithMany()
        .HasForeignKey(p => p.SchedulingStatusId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.HasQueryFilter(x => !x.IsDeleted);
        //builder.HasIndex(f => f.RegisterNumber).IsUnique();
    }
}
