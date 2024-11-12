using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("dnc_personal")]
public class Personal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("username")]
    public required string Username { get; set; }

    [Required]
    [JsonIgnore]
    [Column("password")]
    public string? Password { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Required]
    [Column("mobile_no")]
    public required string MobileNo { get; set; }
    [Required]
    [Column("role")]
    public required string Role { get; set; }
    [Required]
    [Column("address")]
    public required string Address { get; set; }
    [Column("address_desc")]
    public string? AddressDesc { get; set; }
    [Column("point")]
    public int Point { get; set; }
    [Column("coin")]
    public int Coin { get; set; }
    [Column("level")]
    public int Level { get; set; }
    [Column("exp")]
    public int Exp { get; set; }

    public void SetPassword(string password)
    {
        Password = BCrypt.Net.BCrypt.HashPassword(password); // เข้ารหัสรหัสผ่านก่อนเก็บ
    }
}
