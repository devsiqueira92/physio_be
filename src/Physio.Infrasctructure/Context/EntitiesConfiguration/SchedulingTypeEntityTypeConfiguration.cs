using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;

namespace Physio.Infrastructure.Context.EntitiesConfiguration;

public class SchedulingTypeEntityTypeConfiguration : IEntityTypeConfiguration<SchedulingTypeEntity>
{
    public void Configure(EntityTypeBuilder<SchedulingTypeEntity> builder)
    {
        builder.ToTable("TB_SCHEDULING_TYPE");

        builder.Property(f => f.Name)
        .HasColumnName("TXT_NAME")
        .IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);
        //builder.HasIndex(f => f.RegisterNumber).IsUnique();
    }
}
