namespace ProductAPI.Dto;

public class ResultProductDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}