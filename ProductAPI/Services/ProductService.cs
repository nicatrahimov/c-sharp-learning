using AutoMapper;
using ProductAPI.Dto;
using ProductAPI.Mappers;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepo _repo;
    readonly Mapper mapperToDto = AutoMapperProduct.GetEntityToDto();
    private readonly Mapper mapperToEntity = AutoMapperProduct.GetDtoToEntity();

    public ProductService(IProductRepo repo)
    {
        _repo = repo;
    }
    
    public List<ResultProductDto> GetAllProduct()
    {
        List<ResultProductDto> results = new List<ResultProductDto>(); 
        foreach (var product in _repo.GetAllProduct())
        {
            results.Add(mapperToDto.Map<ResultProductDto>(product));
        }
        return results;
    }

    public ResultProductDto GetProductById(Guid id)
    {
       var product = _repo.GetProductById(id);
       return mapperToDto.Map<ResultProductDto>(product);
    }

    public void AddProduct(InputProductDto product)
    {
        Product entity = mapperToEntity.Map<Product>(product);
        _repo.AddProduct(entity);
    }

    public void EditProduct(Guid id, InputProductDto product)
    {
       var entity = mapperToEntity.Map<Product>(product);
        _repo.EditProduct(id,entity);
        
    }

    public void DeleteProduct(Guid id)
    {
        _repo.DeleteProduct(id);
    }
}