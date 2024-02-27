
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


        builder.Property(f => f.UserId)
        .HasColumnName("COD_USER");

        builder.HasOne(p => p.UserEntity)
        .WithMany()
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.NoAction);


       
    }
}
