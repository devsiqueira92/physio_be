using Physio.Domain.Errors;
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class SchedulingEntity : BaseEntity
{
    public DateTime Date { get; set; }
    public string SchedulingType { get; set; }
    public Guid PatientId { get; set; }
    public PatientEntity PatientEntity { get; set; }

    public Guid ProfessionalId { get; set; }
    public ProfessionalEntity ProfessionalEntity { get; set; }

    public Guid SchedulingStatusId { get; set; }
    public StatusSchedulingEntity SchedulingStatusEntity { get; set; }

    public Guid? ClinicId { get; set; }
    public ClinicEntity ClinicEntity { get; set; }

    public static Result<SchedulingEntity> Create(DateTime date, Guid patientId, Guid professionalId, Guid schedulinglId, Guid? clinicId, Guid userId)
    {
        bool isInvalidDate = DateTime.UtcNow.CompareTo(date) > 0;

        if(isInvalidDate)
            return Result.Failure<SchedulingEntity>(DomainErrors.Scheduling.PastDate);

        return new SchedulingEntity
        {
            Date = date,
            PatientId = patientId,
            ProfessionalId = professionalId,
            SchedulingStatusId = schedulinglId,
            ClinicId = clinicId is not null ? clinicId : null,
            CreatedBy = userId
        };
    }


    public Result Update(DateTime date, Guid patientId, Guid professionalId, Guid schedulinglId, Guid? clinicId, Guid userId)
    {
        bool isInvalidDate = DateTime.UtcNow.CompareTo(date) < 0;

        if (isInvalidDate)
        {
            Date = date;
            PatientId = patientId;
            ProfessionalId = professionalId;
            SchedulingStatusId = schedulinglId;
            ClinicId = clinicId is not null ? clinicId : null;
            UpdatedBy = userId;
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
