using System.Data;
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
    
    public List<Product> GetAllProduct()
    {
        string query = "select * from testapi.product";

        using (var connection = _context.CreateConnection())
        {
            var productList = connection.Query<Product>(query);
            return productList.ToList();
        }
    }

        public Product GetProductById(Guid id)
        {
            string query =
                "select * from testapi.product where id = @id";
            
            var parameter = new DynamicParameters();
            parameter.Add("id",id,DbType.Guid);
            
            using (var connection = _context.CreateConnection())
            {
               Product? product = connection.QueryFirstOrDefault<Product>(query, parameter);
               return product;
            }
        }

    public void AddProduct(Product product)
    {
        string query =
            "insert into testapi.product(id, productname, price, description) " +
            "values(@id, @productname, @price, @description)";

        var parameters = new DynamicParameters();
        parameters.Add("id",product.Id,DbType.Guid);
        parameters.Add("productname",product.ProductName,DbType.String);
        parameters.Add("price",product.Price,DbType.Decimal);
        parameters.Add("description",product.Description,DbType.String);
        
        using (var connection = _context.CreateConnection())
        {
            connection.Execute(query, parameters);
        }
    }

    public void EditProduct(Guid id, Product product)
    {
        string query = "UPDATE testapi.product SET ";
        
        var parameters = new DynamicParameters();
        
        if (!string.IsNullOrEmpty(product.ProductName))
        {
            query += "productname = @name, ";
            parameters.Add("name", product.ProductName);
        }
        if (product.Price!=Decimal.Zero)
        {
            query += "price = @price, ";
            parameters.Add("price", product.Price);
        }
        if (!string.IsNullOrEmpty(product.Description))
        {
            query += "description = @desc, ";
            parameters.Add("desc", product.Description);
        }
        query = query.TrimEnd(',', ' ');
        query += " WHERE id = @id";
        parameters.Add("id", id);

        using (var connection = _context.CreateConnection())
        {
            connection.Execute(query, parameters);
        }
    }

    public void DeleteProduct(Guid id)
    {
        string query = "delete from testapi.product where id=@id";
        var parameter = new DynamicParameters();

        using (var connection = _context.CreateConnection())
        {
            connection.Execute(query, parameter);
        }
    }
}