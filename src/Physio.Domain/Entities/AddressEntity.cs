namespace Physio.Domain.Entities;

public sealed class AddressEntity : BaseEntity
{
    public string Street { get; set; }
    public string Number { get; set; }

    public string City { get; set; }
    public string PostalCode { get; set; }

    public Guid? PatientId { get; set; }
    public PatientEntity PatientEntity { get; set; }

    public Guid? ClinicId { get; set; }
    public ClinicEntity ClinicEntity { get; set; }

    public Guid? ProfessionalId { get; set; }
    public ProfessionalEntity ProfessionalEntity { get; set; }


    public static AddressEntity Create(string street, string number, string city, string postalCode, Guid? patietnId, Guid? clinicId, Guid? professionalId, Guid userId)
    {
        return new AddressEntity { 
            Street = street, 
            Number = number, 
            City = city, 
            PostalCode = postalCode,
            PatientId = patietnId,
            ClinicId = clinicId,
            ProfessionalId = professionalId,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = userId 
        };
    }

    public void Update(string street, Guid userId)
    {
        Street = street;
        UpdatedBy = userId;
    }
}
