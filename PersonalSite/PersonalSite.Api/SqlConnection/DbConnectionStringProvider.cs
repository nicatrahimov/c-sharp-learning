using System.Data;
using System.Data.Common;
using PersonalSite.Persistence.Repositories;

namespace PersonalSite.Api.SqlConnection;

public class DbConnectionStringProvider(IConfiguration configuration) : IDbConnectionStringProvider
{
    public string? GetConnectionString()
    {
        return configuration.GetConnectionString("connection");
    }
}