using Physio.Domain.Shared;

namespace Physio.Domain.Entities;

public sealed class ProtocolEntity : BaseEntity
{
    public string Name { get; set; }
    public string Member { get; set; }
    public string Description { get; set; }

    public static Result<ProtocolEntity> Create(string name, string member, string description, Guid userId)
    {
        return new ProtocolEntity { Name = name, Member = member, Description = description, CreatedBy = userId };
    }

    public void Update(string name, string member, string description, Guid userId)
    {
        Name = name;
        Description = description;
        Member = member;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;
    }
}
