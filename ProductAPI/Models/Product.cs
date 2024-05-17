namespace ProductAPI.Models;

public class Product
{
    public Guid Id { get; } = Guid.NewGuid();
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}   