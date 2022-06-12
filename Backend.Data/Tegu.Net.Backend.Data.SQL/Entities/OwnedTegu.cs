namespace Tegu.Net.Backend.Data.SQL.Entities;

public class OwnedTegu
{
    [Key]
    public Guid Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(50)]
    public string Name { get; set; }

    #region Navigation - TeguType

    public int TeguTypeId { get; set; }

    [ForeignKey(nameof(TeguTypeId))]
    public virtual TeguType TeguType { get; set; }

    #endregion

    #region Navigation - Owner

    public Guid OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public virtual User Owner { get; set; }

    #endregion
}