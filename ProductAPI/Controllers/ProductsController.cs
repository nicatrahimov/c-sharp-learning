using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dto;
using ProductAPI.Models;
using ProductAPI.Repositories;
using ProductAPI.Services;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_service.GetAllProduct());
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(Guid id)
    {
        var dto = _service.GetProductById(id);
        if (dto != null)
        {
            return Ok(dto);
        }
        return BadRequest("Nothing found with id: " + id);
    }

    [HttpPost]
    public IActionResult AddProduct(InputProductDto dto)
    {
        var result = _service.AddProduct(dto);
        if (result == 1)
        {
            return Created();
        }
        return BadRequest("Cannot adding this product");
    }

    [HttpDelete]
    public IActionResult DeleteProduct(Guid id)
    {
        var result = _service.DeleteProduct(id);
        if (result == 1)
        {
            return Ok("Successfully deleted");
        }
        return BadRequest("No product with id: " + id);
    }

    [HttpPut("{id}")]
    public IActionResult EditProduct(Guid id, InputProductDto product)
    {
        var result = _service.EditProduct(id, product);
        if (result == 1)
        {
            return Ok("Edited successfully");
        }
        return BadRequest("Cant find product with id: " + id);
    }
}