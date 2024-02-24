using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<PatientEntity>
{
    public void Configure(EntityTypeBuilder<PatientEntity> builder)
    {
        builder.ToTable("TB_PATIENT");

        builder.Property(f => f.Name)
       .HasColumnName("TXT_NAME")
       .IsRequired();


        builder.Property(f => f.BirthDate)
        .HasColumnName("DAT_BIRTH_DATE");

        builder.Property(f => f.Contact)
        .HasColumnName("TXT_CONTACT")
        .IsRequired();


        //builder.HasIndex(b => b.BloodType).IsUnique();
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
