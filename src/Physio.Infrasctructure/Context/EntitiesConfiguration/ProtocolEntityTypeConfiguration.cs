using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class ProtocolEntityTypeConfiguration : IEntityTypeConfiguration<ProtocolEntity>
{
    public void Configure(EntityTypeBuilder<ProtocolEntity> builder)
    {
        builder.ToTable("TB_PROTOCOL");

        builder.Property(f => f.Name)
       .HasColumnName("TXT_NAME")
       .IsRequired();


        builder.Property(f => f.Member)
        .HasColumnName("TXT_MEMBER");

        builder.Property(f => f.Description)
        .HasColumnName("TXT_DESCRIPTION")
        .IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
