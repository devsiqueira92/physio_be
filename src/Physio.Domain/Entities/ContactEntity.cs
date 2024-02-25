namespace Physio.Domain.Entities;

public sealed class ContactEntity : BaseEntity
{
    public string Contact { get; set; }
    public string Type { get; set; }

    public Guid? PatientId { get; set; }
    public PatientEntity PatientEntity { get; set; }

    public Guid? ClinicId { get; set; }
    public ClinicEntity ClinicEntity { get; set; }

    public Guid? ProfessionalId { get; set; }
    public ProfessionalEntity ProfessionalEntity { get; set; }

    public static ContactEntity Create(string contact, string type, Guid? patietnId, Guid? clinicId, Guid? professionalId, Guid userId)
    {
        return new ContactEntity { 
            Contact = contact, 
            Type = type,
            PatientId = patietnId,
            ClinicId = clinicId,
            ProfessionalId = professionalId,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = userId 
        };
    }

    public void Update(string contact, Guid userId)
    {
        Contact = contact;
        UpdatedBy = userId;
    }
}
