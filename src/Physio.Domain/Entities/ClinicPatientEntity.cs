
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public class ClinicPatientEntity : BaseEntity
{
    public Guid PatientId { get; set; }
    public PatientEntity PatientEntity { get; set; }

    public Guid ClinicId { get; set; }
    public ClinicEntity ClinicEntity { get; set; }

    public static Result<ClinicPatientEntity> Create(PatientEntity patient, Guid clinic, Guid userId)
    {

        return new ClinicPatientEntity
        {
            CreatedOn = DateTime.UtcNow,
            PatientEntity = patient,
            PatientId = patient.Id,
            ClinicId = clinic,
            CreatedBy = userId
        };
    }
}
