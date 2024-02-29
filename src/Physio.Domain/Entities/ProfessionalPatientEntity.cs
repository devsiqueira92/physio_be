
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public class ProfessionalPatientEntity : BaseEntity
{
    public Guid PatientId { get; set; }
    public PatientEntity PatientEntity { get; set; }

    public Guid ProfessionalId { get; set; }
    public ProfessionalEntity ProfessionalEntity { get; set; }

    public static Result<ProfessionalPatientEntity> Create(PatientEntity patient, Guid professionalId, Guid userId)
    {

        return new ProfessionalPatientEntity
        {
            CreatedOn = DateTime.UtcNow,
            PatientEntity = patient,
            PatientId = patient.Id,
            ProfessionalId = professionalId,
            CreatedBy = userId
        };
    }
}
