namespace Physio.Domain.Entities;

public abstract class PersonEntity : BaseEntity
{
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
}
