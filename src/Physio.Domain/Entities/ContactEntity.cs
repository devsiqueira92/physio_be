using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class ContactEntity : BaseEntity
{
    public string Contact { get; set; }
    public string Type { get; set; }
    public string UserId { get; set; }
    public UserEntity UserEntity { get; set; }

    public static Result<ContactEntity> Create(string contact, string type, Guid userId)
    {
        return new ContactEntity { 
            Contact = contact, 
            Type = type,
            UserId = userId.ToString(), //logged user

            CreatedOn = DateTime.UtcNow,
            CreatedBy = userId 
        };
    }

    public void Update(string contact, string type, Guid userId)
    {
        Contact = contact;
        Type = type;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow; 
    }
}
