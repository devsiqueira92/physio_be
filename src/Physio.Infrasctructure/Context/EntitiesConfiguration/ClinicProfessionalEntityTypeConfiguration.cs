
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrasctructure.Context.EntitiesConfiguration;

public class ClinicProfessionalEntityTypeConfiguration : IEntityTypeConfiguration<ClinicProfessionalEntity>
{
    public void Configure(EntityTypeBuilder<ClinicProfessionalEntity> builder)
    {
        builder.ToTable("TB_CLINIC_PROFESSIONAL");

        builder.HasKey(pc => new { pc.ProfessionalId, pc.ClinicId });

        builder.Property(f => f.ProfessionalId)
        .HasMaxLength(36)
        .HasColumnName("COD_PROFESSIONAL");



        builder.HasOne(pc => pc.ProfessionalEntity)
        .WithMany(p => p.Clinics)
        .HasForeignKey(pc => pc.ProfessionalId);

        builder.Property(f => f.ClinicId)
        .HasMaxLength(36)
        .HasColumnName("COD_CLINIC");

        builder.HasOne(pc => pc.ClinicEntity)
        .WithMany(c => c.Professionals)
        .HasForeignKey(pc => pc.ClinicId);
    }
}
