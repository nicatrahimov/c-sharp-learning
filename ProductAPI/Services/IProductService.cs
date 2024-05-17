using ProductAPI.Dto;

namespace ProductAPI.Services;

public interface IProductService
{
    List<ResultProductDto> GetAllProduct();
    
    ResultProductDto GetProductById(Guid id);

    int AddProduct(InputProductDto product);

    int EditProduct(Guid id,InputProductDto product);

    int DeleteProduct(Guid id);
}