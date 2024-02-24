namespace Physio.Domain.Entities;

public sealed class ClinicEntity : BaseEntity
{
    public string Name { get; set; }
    public List<AddressEntity> AddressList { get; set; }
    public List<ContactEntity> ContactList { get; set; }

    public static ClinicEntity Create(string name)
    {
        return new ClinicEntity { Name = name };
    }

    public void Update(string name, Guid userId)
    {
        Name = name;
        UpdatedBy = userId;
    }
}
