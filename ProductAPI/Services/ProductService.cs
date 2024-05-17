using AutoMapper;
using ProductAPI.Dto;
using ProductAPI.Mappers;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepo _repo;
    private readonly Mapper mapperToDto = AutoMapperProduct.GetEntityToDto();
    private readonly Mapper mapperToEntity = AutoMapperProduct.GetDtoToEntity();

    public ProductService(IProductRepo repo)
    {
        _repo = repo;
    }

    public List<ResultProductDto> GetAllProduct()
    {
        var results = new List<ResultProductDto>();
        foreach (var product in _repo.GetAllProduct()) results.Add(mapperToDto.Map<ResultProductDto>(product));
        return results;
    }

    public ResultProductDto GetProductById(Guid id)
    {
        var product = _repo.GetProductById(id);
        if (product != null) return mapperToDto.Map<ResultProductDto>(product);
        return null;
    }

    public int AddProduct(InputProductDto product)
    {
        var entity = mapperToEntity.Map<Product>(product);
        return _repo.AddProduct(entity);
    }

    public int EditProduct(Guid id, InputProductDto product)
    {
        var entity = mapperToEntity.Map<Product>(product);
        return _repo.EditProduct(id, entity);
    }

    public int DeleteProduct(Guid id)
    {
        return _repo.DeleteProduct(id);
    }
}