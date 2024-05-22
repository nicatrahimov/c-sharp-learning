using System.Data;
using Npgsql;
using PersonalSite.Application.Repositories;

namespace PersonalSite.Persistence.Repositories;

public class DbConnectionFactory(IDbConnectionStringProvider connectionStringProvider) : IDbConnectionFactory
{
    private readonly string? _connectionString = connectionStringProvider.GetConnectionString();

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}