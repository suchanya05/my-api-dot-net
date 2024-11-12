using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("dnc_product")]
public class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("product_name")]
    public required string ProductName { get; set; }
    [Column("price")]
    public int Price { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("matirial_code")]
    public string? MatirialCode { get; set; }
    [Column("qty")]
    public int Qty { get; set; } //จำนวน
    [Column("product_type")]
    public string? ProductType { get; set; }
    [Column("Product_sub_type")]
    public string? ProductSubType { get; set; }
    [Column("product_color")]
    public string? ProductColor { get; set; }
    [Column("serial_type")]
    public string? SerialType { get; set; }

}
