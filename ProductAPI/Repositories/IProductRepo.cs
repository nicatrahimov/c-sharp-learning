using ProductAPI.Models;

namespace ProductAPI.Repositories;

public interface IProductRepo
{
   IEnumerable<Product> GetAllProduct();
}