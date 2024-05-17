namespace ProductAPI.Dto;

public class InputProductDto
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}