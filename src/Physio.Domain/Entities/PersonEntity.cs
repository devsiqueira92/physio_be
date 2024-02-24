namespace Physio.Domain.Entities;

public abstract class PersonEntity : BaseEntity
{
    public string? Name { get; set; }
    //public List<AddressEntity>? AddressList { get; set; }
    //public List<ContactEntity>? ContactList { get; set; }
    public DateOnly BirthDate { get; set; }
}
