using ProductAPI.Dto;
using ProductAPI.Models;

namespace ProductAPI.Repositories;

public interface IProductRepo
{
    List<Product> GetAllProduct();
    Product GetProductById(Guid id);

    int AddProduct(Product product);

    int EditProduct(Guid id, Product product);

    int DeleteProduct(Guid id);
}