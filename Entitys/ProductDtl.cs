using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("dnc_product_dtl")]
public class ProductDtl
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("serial_number")]
    public required string SerialNumber { get; set; }
    [Column("mat_code")]
    public required string MatCode { get; set; }
    [Column("qty")]
    public int Qty { get; set; }
}
