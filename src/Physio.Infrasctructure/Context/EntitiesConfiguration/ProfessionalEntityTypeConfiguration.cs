using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class ProfessionalEntityTypeConfiguration : IEntityTypeConfiguration<ProfessionalEntity>
{
    public void Configure(EntityTypeBuilder<ProfessionalEntity> builder)
    {
        builder.ToTable("TB_PROFESSIONAL");

        builder.Property(f => f.Name)
        .HasColumnName("TXT_NAME")
        .HasMaxLength(75)
        .IsRequired();

        builder.Property(f => f.BirthDate)
        .HasColumnName("DAT_BIRTH_DATE");

        builder.Property(f => f.Contact)
       .HasColumnName("TXT_CONTACT")
       .HasMaxLength(15)
       .IsRequired();

        builder.Property(f => f.AppointmentValue)
        .HasColumnName("DEC_APPOINTMENT_VALUE")
        .IsRequired()
        .HasColumnType("decimal(6, 2)");

        builder.Property(f => f.RegisterNumber)
        .HasColumnName("COD_REGISTER_NUMBER")
        .HasMaxLength(10)
        .IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.HasIndex(f => f.RegisterNumber).IsUnique();
    }
}
