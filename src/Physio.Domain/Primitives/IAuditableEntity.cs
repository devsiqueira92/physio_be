namespace Physio.Domain.Primitives
{
    public interface IAuditableEntity
    {
        Guid? CreatedBy { get; set; }

        Guid? UpdatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
