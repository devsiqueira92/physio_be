namespace Physio.Domain.Entities;

public sealed class ContactEntity : BaseEntity
{
    public string Number { get; set; }
    public string Type { get; set; }

    public static ContactEntity Create(string number, string type, Guid userId)
    {
        return new ContactEntity { Number = number, Type = type, CreatedBy = userId };
    }

    public void Update(string number, Guid userId)
    {
        Number = number;
        UpdatedBy = userId;
    }
}
