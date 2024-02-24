
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrasctructure.Context.EntitiesConfiguration;

public class ProfessionalClinicEntityTypeConfiguration : IEntityTypeConfiguration<ProfessionalClinicEntity>
{
    public void Configure(EntityTypeBuilder<ProfessionalClinicEntity> builder)
    {
        builder.ToTable("TB_PROFESSIONAL_CLINIC");

        builder.HasKey(pc => new { pc.ProfessionalId, pc.ClinicId });

        builder.Property(f => f.ProfessionalId)
        .HasColumnName("COD_PROFESSIONAL");



        builder.HasOne(pc => pc.ProfessionalEntity)
        .WithMany(p => p.Clinics)
        .HasForeignKey(pc => pc.ProfessionalId);

        builder.Property(f => f.ClinicId)
        .HasColumnName("COD_CLINIC");

        builder.HasOne(pc => pc.ClinicEntity)
        .WithMany(c => c.Professionals)
        .HasForeignKey(pc => pc.ClinicId);
    }
}
