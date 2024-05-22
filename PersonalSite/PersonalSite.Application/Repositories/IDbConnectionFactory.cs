using System.Data;

namespace PersonalSite.Application.Repositories;

public interface IDbConnectionFactory
{
    public IDbConnection CreateConnection();
}