
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class SchedulingTypeEntity : BaseEntity
{
    public string Name { get; set; }

    public static Result<StatusSchedulingEntity> Create(string name, Guid userId)
    {
        return new StatusSchedulingEntity { Name = name, CreatedBy = userId };
    }

    public Result Update(string name, Guid userId)
    {
        Name = name;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;

        return Result.Success();
    }
}
