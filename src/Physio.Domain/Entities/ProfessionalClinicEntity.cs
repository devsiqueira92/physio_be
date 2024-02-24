
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public class ProfessionalClinicEntity : BaseEntity
{
    public Guid ProfessionalId { get; set; }
    public ProfessionalEntity ProfessionalEntity { get; set; }

    public Guid ClinicId { get; set; }
    public ClinicEntity ClinicEntity { get; set; }

    public static Result<ProfessionalClinicEntity> Create(ProfessionalEntity professional, Guid clinic, Guid userId)
    {

        return new ProfessionalClinicEntity
        {
            CreatedOn = DateTime.UtcNow,
            ProfessionalEntity = professional,
            ProfessionalId = professional.Id,
            ClinicId = clinic,
            CreatedBy = userId
        };
    }
}
