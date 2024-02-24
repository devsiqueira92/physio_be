using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class ClinicEntity : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string IdentificationNumber { get; set; }
    public string UserId { get; set; }
    public UserEntity UserEntity { get; set; }

    public ICollection<ProfessionalClinicEntity> Professionals { get; set; }
    public ICollection<ClinicPatientEntity> Patients { get; set; }

    public static Result<ClinicEntity> Create(string name, string address, string contact, string identificationNumber, Guid userId)
    {
        return new ClinicEntity { 
            Name = name, 
            UserId = userId.ToString(), 
            Address = address,
            Contact = identificationNumber,
            IdentificationNumber = name,
            CreatedBy = userId,
        };
    }

    public void Update(string name, string address, string contact, string identificationNumber, Guid userId)
    {
        Name = name;
        UpdatedBy = userId;
        Address = address;
        Contact = identificationNumber;
        IdentificationNumber = name;
        UpdatedOn = DateTime.UtcNow;
    }
}
