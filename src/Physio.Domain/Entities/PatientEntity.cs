using Physio.Domain.Errors;
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class PatientEntity : PersonEntity
{
    public string Contact { get; set; }
    public ICollection<ClinicPatientEntity> Clinics { get; set; }

    public static Result<PatientEntity> Create(string name, DateOnly birthDate, string contact, Guid userId)
    {
        var isAdult = DateTime.UtcNow.Year - birthDate.Year > 18;
        if (!isAdult)
        {
            return Result.Failure<PatientEntity>(DomainErrors.Patient.ChildError);
        }

        return new PatientEntity { 
            Name = name, 
            BirthDate = birthDate,
            Contact = contact,
            CreatedBy = userId,
        };
    }

    public void Update(string name, DateOnly birthDate, string contact, Guid userId)
    {
        Name = name;
        BirthDate = birthDate;
        Contact = contact;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;
    }
}
