
using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class ProfessionalEntity : PersonEntity
{
    public string RegisterNumber { get; set; }
    public decimal AppointmentValue { get; set; }
    public string Contact { get; set; }
    //public Guid? ClinicId { get; set; }

    public static Result<ProfessionalEntity> Create(string name, DateOnly birthDate, string contact, string registerNumber, decimal appointmentValue, Guid userId) =>
        new ProfessionalEntity { 
            Name = name,
            BirthDate = birthDate,
            Contact = contact,
            RegisterNumber = registerNumber, 
            AppointmentValue = appointmentValue, 
            CreatedBy = userId 
        };

    public void Update(string name, DateOnly birthDate, string contact, string registerNumber, decimal appointmentValue, Guid userId)
    {
        Name = name;
        BirthDate = birthDate;
        Contact = contact;
        RegisterNumber = registerNumber;
        AppointmentValue = appointmentValue;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;
    }
}
