using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class AddressEntity : BaseEntity
{
    public string Street { get; set; }
    public string Number { get; set; }

    public string City { get; set; }
    public string PostalCode { get; set; }

    public string UserId { get; set; }
    public UserEntity UserEntity { get; set; }


    public static Result<AddressEntity> Create(string street, string number, string city, string postalCode, string userId)
    {
        return new AddressEntity { 
            Street = street, 
            Number = number, 
            City = city, 
            PostalCode = postalCode,
            UserId = userId,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = Guid.Parse(userId)
        };
    }

    public void Update(string street, Guid userId)
    {
        Street = street;
        UpdatedBy = userId;
    }
}
