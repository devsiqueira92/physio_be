
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrasctructure.Context.EntitiesConfiguration;

public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ToTable("TB_ADDRESS");


        builder.Property(f => f.City)
        .HasMaxLength(40)
        .IsRequired()
        .HasColumnName("TXT_CITY");

        builder.Property(f => f.Street)
        .HasMaxLength(80)
        .IsRequired()
        .HasColumnName("TXT_STREET");

        builder.Property(f => f.Number)
        .HasMaxLength(6)
        .IsRequired()
        .HasColumnName("TXT_NUMBER");

        builder.Property(f => f.PostalCode)
        .HasMaxLength(15)
        .HasColumnName("TXT_POSTAL_CODE");


        builder.Property(f => f.PatientId)
        .HasMaxLength(36)
        .HasColumnName("COD_PATIENT");

        builder.HasOne(p => p.PatientEntity)
        .WithMany()
        .HasForeignKey(p => p.PatientId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(f => f.ProfessionalId)
        .HasMaxLength(36)
        .HasColumnName("COD_PROFESSIONAL");

        builder.HasOne(p => p.ProfessionalEntity)
        .WithMany()
        .HasForeignKey(p => p.ProfessionalId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(f => f.ClinicId)
        .HasMaxLength(36)
        .HasColumnName("COD_CLINIC");

        builder.HasOne(p => p.ClinicEntity)
        .WithMany()
        .HasForeignKey(p => p.ClinicId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
