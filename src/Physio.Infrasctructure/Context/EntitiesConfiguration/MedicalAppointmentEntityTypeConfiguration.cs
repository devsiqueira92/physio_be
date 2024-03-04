﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class MedicalAppointmentEntityTypeConfiguration : IEntityTypeConfiguration<MedicalAppointmentEntity>
{
    public void Configure(EntityTypeBuilder<MedicalAppointmentEntity> builder)
    {
        builder.ToTable("TB_MEDICAL_APPOINTMENT");

        builder.Property(f => f.BeatsPerMinute)
        .HasColumnName("TXT_BEATS_MINUTE")
        .HasMaxLength(4);

        builder.Property(f => f.BloodPressure)
        .HasColumnName("TXT_BLOOD_PRESSURE")
        .HasMaxLength(10);

        builder.Property(f => f.BloodOxygenation)
        .HasColumnName("TXT_BLOOD_OXYGENATION")
        .HasMaxLength(10);

        builder.Property(f => f.Evolution)
        .HasColumnName("TXT_EVOLUTION")
        .HasMaxLength(2000)
        .IsRequired();

        builder.Property(f => f.Notes)
        .HasColumnName("TXT_NOTES")
        .HasMaxLength(2000);

        builder.Property(f => f.Weight)
        .HasColumnName("DBL_WEIGHT")
        .HasColumnType("decimal(6, 2)");


        builder.Property(f => f.ClinicSchedulingId)
        .HasColumnName("COD_CLINIC_SCHEDULING")
        .HasMaxLength(36)
        .IsRequired();

        builder.HasOne(p => p.ClinicSchedulingEntity)
        .WithMany()
        .HasForeignKey(p => p.ClinicSchedulingId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(f => f.ProfessionalSchedulingId)
        .HasColumnName("COD_PROFESSIONAL_SCHEDULING")
        .HasMaxLength(36)
        .IsRequired();

        builder.HasOne(p => p.ProfessionalSchedulingEntity)
        .WithMany()
        .HasForeignKey(p => p.ProfessionalSchedulingId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.HasQueryFilter(x => !x.IsDeleted);
        //builder.HasIndex(f => f.RegisterNumber).IsUnique();
    }
}
