using Dapper;
using ProductAPI.Models;
using ProductAPI.Models.Data;

namespace ProductAPI.Repositories;

public class ProductRepo : IProductRepo
{
    private readonly DapperDbContext _context;

    public ProductRepo(DapperDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Product> GetAllProduct()
    {
        string query = "select * from testapi.product";
        
        using (var connection = _context.CreateConnection())
        {
            var productList =  connection.Query<Product>(query);
            return productList;
        }
    }
}