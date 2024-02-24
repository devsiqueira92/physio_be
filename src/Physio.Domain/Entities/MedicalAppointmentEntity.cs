
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class MedicalAppointmentEntity : BaseEntity
{
    public string BeatsPerMinute { get; set; }
    public string BloodPressure { get; set; }
    public string BloodOxygenation { get; set; }
    public string Evolution { get; set; }
    public string Notes { get; set; }
    public decimal? Weight { get; set; }

    public Guid SchedulingId { get; set; }
    public SchedulingEntity SchedulingEntity { get; set; }

    public static Result<MedicalAppointmentEntity> Create(string beatsPerMinute, string bloodPressure, string bloodOxygenation, string evolution, string notes, decimal? weight, Guid schedulingId, Guid userId) =>
        new MedicalAppointmentEntity {
            BeatsPerMinute = beatsPerMinute,
            BloodPressure = bloodPressure,
            BloodOxygenation = bloodOxygenation,
            Evolution = evolution,
            Notes = notes,
            Weight = weight,
            SchedulingId = schedulingId,
            CreatedBy = userId,
        };

    public Result Update(string beatsPerMinute, string bloodPressure, string bloodOxygenation, string evolution, string notes, decimal weight, Guid schedulingId, Guid userId)
    {
        BeatsPerMinute = beatsPerMinute;
        BloodPressure = bloodPressure;
        BloodOxygenation = bloodOxygenation;
        Evolution = evolution;
        Notes = notes;
        Weight = weight;
        SchedulingId = schedulingId;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;

        return Result.Success();
    }
}