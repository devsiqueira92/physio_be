using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class ClinicEntityTypeConfiguration : IEntityTypeConfiguration<ClinicEntity>
{
    public void Configure(EntityTypeBuilder<ClinicEntity> builder)
    {
        builder.ToTable("TB_CLINIC");

        builder.Property(f => f.Name)
        .HasColumnName("TXT_NAME")
        .IsRequired();

        builder.Property(f => f.IdentificationNumber)
        .HasColumnName("TXT_IDENTIFICATION_NUMBER")
        .HasMaxLength(20)
        .IsRequired();

        builder.Property(f => f.UserId)
        .HasColumnName("COD_USER");

        builder.HasOne(p => p.UserEntity)
        .WithMany()
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        
        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.HasIndex(b => b.IdentificationNumber).IsUnique();
        builder.HasIndex(f => f.UserId).IsUnique();
    }
}
