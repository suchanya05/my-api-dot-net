public class ProductListDto
{
    //public int Id { get; set; }
    public required string ProductName { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
    public string? MatirialCode { get; set; }
    public int Qty { get; set; }
    public string? ProductType { get; set; }
    public string? ProductSubType { get; set; }
    public string? ProductColor { get; set; }
    public string? SerialType { get; set; }
}