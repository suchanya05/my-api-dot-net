public class PersonalDto
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
    public required string MobileNo { get; set; }
    public required string Role { get; set; }
    public required string Address { get; set; }
    public string? AddressDesc { get; set; }
    public int Point { get; set; }
    public int Coin { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }

}