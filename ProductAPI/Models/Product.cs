namespace ProductAPI.Models;

public class Product
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }

        
}