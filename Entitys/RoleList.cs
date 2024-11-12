using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("dnc_role_list")]
public class RoleList
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("role_name")]
    public required string RoleName { get; set; }
    [Column("description")]
    public string? Description { get; set; }
}