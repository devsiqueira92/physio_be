
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrasctructure.Context.EntitiesConfiguration;

public class ClinicPatientEntityTypeConfiguration : IEntityTypeConfiguration<ClinicPatientEntity>
{
    public void Configure(EntityTypeBuilder<ClinicPatientEntity> builder)
    {
        builder.ToTable("TB_CLINIC_PATIENT");

        builder.HasKey(pc => new { pc.PatientId, pc.ClinicId });

        builder.Property(f => f.PatientId)
        .HasMaxLength(36)
        .HasColumnName("COD_PATIENT");

        builder.HasOne(pc => pc.PatientEntity)
        .WithMany(p => p.Clinics)
        .HasForeignKey(pc => pc.PatientId);

        builder.Property(f => f.ClinicId)
        .HasMaxLength(36)
        .HasColumnName("COD_CLINIC");

        builder.HasOne(pc => pc.ClinicEntity)
        .WithMany(c => c.Patients)
        .HasForeignKey(pc => pc.ClinicId);
    }
}
