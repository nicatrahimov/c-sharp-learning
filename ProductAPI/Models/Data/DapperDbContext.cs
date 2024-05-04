using System.Data;
using Npgsql;

namespace ProductAPI.Models.Data;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string connectionString;

    public DapperDbContext(IConfiguration configuration)
    {
      _configuration = configuration;
      connectionString = _configuration.GetConnectionString("connection");
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(connectionString);
}