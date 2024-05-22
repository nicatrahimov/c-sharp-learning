using Microsoft.Extensions.DependencyInjection;
using PersonalSite.Application.Repositories;
using PersonalSite.Application.Services.CertificateService;
using PersonalSite.Persistence.Repositories;

namespace PersonalSite.Persistence;

public static class Registration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ISqlBaseRepository, SqlBaseRepository>();
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
    }
}