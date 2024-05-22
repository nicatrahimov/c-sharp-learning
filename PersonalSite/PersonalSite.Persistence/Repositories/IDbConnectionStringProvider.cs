namespace PersonalSite.Persistence.Repositories;

public interface IDbConnectionStringProvider
{
    string? GetConnectionString();
}