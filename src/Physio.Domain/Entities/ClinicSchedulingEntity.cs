using Physio.Domain.Errors;
using Physio.Domain.Shared;
using static Physio.Domain.Errors.DomainErrors;

namespace Physio.Domain.Entities;

public sealed class ClinicSchedulingEntity : BaseEntity
{
    public DateTime Date { get; set; }

    public Guid SchedulingTypeId { get; set; }
    public SchedulingTypeEntity SchedulingTypeEntity { get; set; }
 
    public Guid PatientId { get; set; }
    public PatientEntity PatientEntity { get; set; }

    public Guid ProfessionalId { get; set; }
    public ProfessionalEntity ProfessionalEntity { get; set; }

    public Guid SchedulingStatusId { get; set; }
    public StatusSchedulingEntity SchedulingStatusEntity { get; set; }

    public Guid ClinicId { get; set; }
    public ClinicEntity ClinicEntity { get; set; }


    public static Result<ClinicSchedulingEntity> Create(DateTime date, Guid patientId, Guid professionalId, Guid schedulinglId, Guid clinicId, Guid schedulingTypeId, Guid userId)
    {
        bool isInvalidDate = DateTime.UtcNow.CompareTo(date) > 0;

        if(isInvalidDate)
            return Result.Failure<ClinicSchedulingEntity>(DomainErrors.Scheduling.PastDate);

        return new ClinicSchedulingEntity
        {
            Date = date,
            PatientId = patientId,
            ProfessionalId = professionalId,
            SchedulingStatusId = schedulinglId,
            SchedulingTypeId = schedulingTypeId,
            ClinicId = clinicId,
            CreatedBy = userId
        };
    }


    public Result Update(DateTime date, Guid patientId, Guid professionalId, Guid schedulinglId, Guid clinicId, Guid schedulingTypeId, Guid userId)
    {
        bool isInvalidDate = DateTime.UtcNow.CompareTo(date) < 0;

        if (isInvalidDate)
        {
            Date = date;
            PatientId = patientId;
            ProfessionalId = professionalId;
            SchedulingStatusId = schedulinglId;
            SchedulingTypeId = schedulingTypeId;
            UpdatedBy = userId;
            ClinicId = clinicId;
            UpdatedOn = DateTime.UtcNow;

            return Result.Success();
        }

        return Result.Failure(DomainErrors.Scheduling.PastDate);
    }

    public Result UpdateStatus(Guid schedulinglId, Guid userId)
    {
        SchedulingStatusId = schedulinglId;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;

        return Result.Success();
    }
}
