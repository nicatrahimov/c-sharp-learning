using ProductAPI.Dto;

namespace ProductAPI.Services;

public interface IProductService
{
    List<ResultProductDto> GetAllProduct();
    
    ResultProductDto GetProductById(Guid id);

    void AddProduct(InputProductDto product);

    void EditProduct(Guid id,InputProductDto product);

    void DeleteProduct(Guid id);
}