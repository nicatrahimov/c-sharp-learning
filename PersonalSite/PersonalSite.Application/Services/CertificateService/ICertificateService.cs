using PersonalSite.Application.Dtos;

namespace PersonalSite.Application.Services.CertificateService;

public interface ICertificateService
{
    Task<List<ResponseCertificate>> GetAllCertificates();

    Task<ResponseCertificate> GetCertificateById(Guid id);

    Task<string> EditCertificateById(Guid id, RequestCertificate requestCertificate);

    Task<string> DeleteCertificateById(Guid id);

    Task<string> AddCertificate(RequestCertificate requestCertificate);
}