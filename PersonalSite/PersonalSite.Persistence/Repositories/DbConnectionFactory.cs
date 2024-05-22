using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using PersonalSite.Application.Repositories;

namespace PersonalSite.Persistence.Repositories;

public sealed class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connection");
    }
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
