using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class ClinicSchedulingEntity : BaseEntity
{
    public Guid ClinicId { get; set; }
    public ClinicEntity ClinicEntity { get; set; }
    public Guid SchedulingId { get; set; }
    public SchedulingEntity SchedulingEntity { get; set; }

    public static Result<ClinicSchedulingEntity> Create(Guid clinicId, SchedulingEntity scheduling, Guid userId)
    {
        return new ClinicSchedulingEntity
        {
            ClinicId = clinicId,
            SchedulingId = scheduling.Id,
            SchedulingEntity = scheduling,
            CreatedBy = userId
        };
    }

    public Result Update(Guid clinicId, Guid schedulingId, Guid userId)
    {
        UpdatedBy = userId;
        ClinicId = clinicId;
        SchedulingId = schedulingId;
        UpdatedOn = DateTime.UtcNow;

        return Result.Success();
    }
}
