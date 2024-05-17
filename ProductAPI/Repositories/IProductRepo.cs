using ProductAPI.Dto;
using ProductAPI.Models;

namespace ProductAPI.Repositories;

public interface IProductRepo
{
   List<Product> GetAllProduct();
   Product GetProductById(Guid id);

   void AddProduct(Product product);

   void EditProduct(Guid id,Product product);

   void DeleteProduct(Guid id);
   
}