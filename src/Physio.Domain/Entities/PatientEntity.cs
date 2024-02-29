using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class PatientEntity : PersonEntity
{
    public string IdentificationNumber { get; set; }
    public string Contact { get; set; }

    public ICollection<ClinicPatientEntity> Clinics { get; set; }
    public ICollection<ProfessionalPatientEntity> Professionals { get; set; }

    public static Result<PatientEntity> Create(string name, DateOnly birthDate, string contact, string identificationNumber, Guid userId)
    {
        return new PatientEntity { 
            Name = name, 
            BirthDate = birthDate,
            Contact = contact,
            CreatedBy = userId,
            IdentificationNumber = identificationNumber
        };
    }

    public void Update(string name, DateOnly birthDate, string contact, string identificationNumber, Guid userId)
    {
        Name = name;
        BirthDate = birthDate;
        Contact = contact;
        UpdatedBy = userId;
        IdentificationNumber = identificationNumber;
        UpdatedOn = DateTime.UtcNow;
    }
}
