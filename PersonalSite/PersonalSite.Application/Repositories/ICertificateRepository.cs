using PersonalSite.Application.Dtos;
using PersonalSite.Domain.Entities;

namespace PersonalSite.Application.Repositories;

public interface ICertificateRepository : ISqlBaseRepository<Certificate, RequestCertificate>
{
}