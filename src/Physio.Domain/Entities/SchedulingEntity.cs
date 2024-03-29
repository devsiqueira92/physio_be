﻿using Physio.Domain.Errors;
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class SchedulingEntity : BaseEntity
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

    public static Result<SchedulingEntity> Create(DateTime date, Guid patientId, Guid professionalId, Guid schedulingStatuslId, Guid schedulingTypeId, Guid userId)
    {
        bool isInvalidDate = DateTime.UtcNow.CompareTo(date) > 0;

        if(isInvalidDate)
            return Result.Failure<SchedulingEntity>(DomainErrors.Scheduling.PastDate);

        return new SchedulingEntity
        {
            Date = date,
            PatientId = patientId,
            ProfessionalId = professionalId,
            SchedulingStatusId = schedulingStatuslId,
            SchedulingTypeId = schedulingTypeId,
            CreatedBy = userId
        };
    }


    public Result Update(DateTime date, Guid patientId, Guid professionalId, Guid schedulinglId, Guid schedulingTypeId, Guid userId)
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
