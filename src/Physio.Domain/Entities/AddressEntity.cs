using Physio.Domain.Primitives;

namespace Physio.Domain.Entities;

public sealed class AddressEntity : BaseEntity
{
    public string Street { get; set; }
    public string Number { get; set; }

    public string City { get; set; }
    public string PostalCode { get; set; }


    public static AddressEntity Create(string street, string number, string city, string postalCode, Guid userId)
    {
        return new AddressEntity { Street = street, Number = number, City = city, PostalCode = postalCode, CreatedBy = userId };
    }

    public void Update(string street, Guid userId)
    {
        Street = street;
        UpdatedBy = userId;
    }
}
