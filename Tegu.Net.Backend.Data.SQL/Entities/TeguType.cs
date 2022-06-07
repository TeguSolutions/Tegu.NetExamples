namespace Tegu.Net.Backend.Data.SQL.Entities;

public class TeguType
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(40)]
    public string FullName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(30)]
    public string Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(30)]
    public string LatinName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(20)]
    public string Color { get; set; }
}