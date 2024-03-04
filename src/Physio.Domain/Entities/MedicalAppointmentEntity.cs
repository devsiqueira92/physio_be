
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

    public Guid? ProfessionalSchedulingId { get; set; }
    public ProfessionalSchedulingEntity ProfessionalSchedulingEntity { get; set; }

    public Guid? ClinicSchedulingId { get; set; }
    public ClinicSchedulingEntity ClinicSchedulingEntity { get; set; }

    public static Result<MedicalAppointmentEntity> Create(string beatsPerMinute, string bloodPressure, string bloodOxygenation, string evolution, string notes, decimal? weight, Guid schedulingId, Guid userId) =>
        new MedicalAppointmentEntity {
            BeatsPerMinute = beatsPerMinute,
            BloodPressure = bloodPressure,
            BloodOxygenation = bloodOxygenation,
            Evolution = evolution,
            Notes = notes,
            Weight = weight,
            //SchedulingId = schedulingId,
            CreatedBy = userId,
        };

    public static Result<MedicalAppointmentEntity> CreateAsProfessional(string beatsPerMinute, string bloodPressure, string bloodOxygenation, string evolution, string notes, decimal? weight, Guid schedulingId, Guid userId) =>
       new MedicalAppointmentEntity
       {
           BeatsPerMinute = beatsPerMinute,
           BloodPressure = bloodPressure,
           BloodOxygenation = bloodOxygenation,
           Evolution = evolution,
           Notes = notes,
           Weight = weight,
           ProfessionalSchedulingId = schedulingId,
           CreatedBy = userId,
       };

    public static Result<MedicalAppointmentEntity> CreateAsClinic(string beatsPerMinute, string bloodPressure, string bloodOxygenation, string evolution, string notes, decimal? weight, Guid schedulingId, Guid userId) =>
       new MedicalAppointmentEntity
       {
           BeatsPerMinute = beatsPerMinute,
           BloodPressure = bloodPressure,
           BloodOxygenation = bloodOxygenation,
           Evolution = evolution,
           Notes = notes,
           Weight = weight,
           ClinicSchedulingId = schedulingId,
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
        //SchedulingId = schedulingId;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;

        return Result.Success();
    }
}