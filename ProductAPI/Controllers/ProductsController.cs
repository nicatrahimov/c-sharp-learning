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
      ResultProductDto dto = _service.GetProductById(id);
      return Ok(dto);
  }

  [HttpPost]
  public IActionResult AddProduct(InputProductDto dto)
  {
      _service.AddProduct(dto);
      return Created();
  }

  [HttpDelete]
  public IActionResult DeleteProduct(Guid id)
  {
      _service.DeleteProduct(id);
      return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult EditProduct(Guid id, InputProductDto product)
  {
      _service.EditProduct(id,product);
      return Ok();
  }
}