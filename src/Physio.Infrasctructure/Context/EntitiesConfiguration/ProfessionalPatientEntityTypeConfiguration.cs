
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrasctructure.Context.EntitiesConfiguration;

public class ProfessionalPatientEntityTypeConfiguration : IEntityTypeConfiguration<ProfessionalPatientEntity>
{
    public void Configure(EntityTypeBuilder<ProfessionalPatientEntity> builder)
    {
        builder.ToTable("TB_PROFESSIONAL_PATIENT");

        builder.HasKey(pc => new { pc.PatientId, pc.ProfessionalId });

        builder.Property(f => f.PatientId)
        .HasMaxLength(36)
        .HasColumnName("COD_PATIENT");

        builder.HasOne(pc => pc.PatientEntity)
        .WithMany(p => p.Professionals)
        .HasForeignKey(pc => pc.PatientId);

        builder.Property(f => f.ProfessionalId)
        .HasMaxLength(36)
        .HasColumnName("COD_PROFESSIONAL");

        builder.HasOne(pc => pc.ProfessionalEntity)
        .WithMany(c => c.Patients)
        .HasForeignKey(pc => pc.ProfessionalId);
    }
}
