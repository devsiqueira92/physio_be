using System.ComponentModel.DataAnnotations.Schema;

namespace Physio.Domain.Entities;

public abstract class BaseEntity
{
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();


    [Column("FLG_IS_DELETED")]
    public bool IsDeleted { get; set; } = false;

    [Column("DAT_UPDATED_ON")]
    public DateTime? UpdatedOn { get; set; }
    [Column("COD_UPDATED_BY")]
    public Guid? UpdatedBy { get; set; }

    [Column("DAT_CREATED_ON")]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    [Column("COD_CREATED_BY")]
    public Guid CreatedBy { get; set; }

    public void Delete(Guid userId)
    {
        IsDeleted = true;
        UpdatedBy = userId;
        UpdatedOn = DateTime.UtcNow;
    }
}
