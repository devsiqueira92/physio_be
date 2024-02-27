
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrasctructure.Context.EntitiesConfiguration;

public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<ContactEntity>
{
    public void Configure(EntityTypeBuilder<ContactEntity> builder)
    {
        builder.ToTable("TB_CONTACT");

        builder.Property(f => f.Contact)
        .HasMaxLength(20)
        .HasColumnName("TXT_CONTACT");

        builder.Property(f => f.Type)
        .HasMaxLength(20)
        .HasColumnName("TXT_TYPE");


        //builder.Property(f => f.PatientId)
        //.HasMaxLength(36)
        //.HasColumnName("COD_PATIENT");

        //builder.HasOne(p => p.PatientEntity)
        //.WithMany()
        //.HasForeignKey(p => p.PatientId)
        //.OnDelete(DeleteBehavior.NoAction);


        //builder.Property(f => f.ProfessionalId)
        //.HasMaxLength(36)
        //.HasColumnName("COD_PROFESSIONAL");

        //builder.HasOne(p => p.ProfessionalEntity)
        //.WithMany()
        //.HasForeignKey(p => p.ProfessionalId)
        //.OnDelete(DeleteBehavior.NoAction);


        //builder.Property(f => f.ClinicId)
        //.HasMaxLength(36)
        //.HasColumnName("COD_CLINIC");

        //builder.HasOne(p => p.ClinicEntity)
        //.WithMany()
        //.HasForeignKey(p => p.ClinicId)
        //.OnDelete(DeleteBehavior.NoAction);



        builder.Property(f => f.UserId)
        .HasColumnName("COD_USER");

        builder.HasOne(p => p.UserEntity)
        .WithMany()
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
