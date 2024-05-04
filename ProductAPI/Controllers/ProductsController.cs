using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepo _repo;

    public ProductsController(IProductRepo productRepo)
    {
        _repo = productRepo;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_repo.GetAllProduct());
    }
}