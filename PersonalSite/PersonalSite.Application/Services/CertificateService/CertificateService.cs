using PersonalSite.Application.Dtos;
using PersonalSite.Application.Repositories;

namespace PersonalSite.Application.Services.CertificateService;

public class CertificateService(ICertificateRepository repository) : ICertificateService
{
    public async Task<List<ResponseCertificate>> GetAllCertificates()
    {
        List<ResponseCertificate> responseCertificates = new List<ResponseCertificate>();
        var certificates = await repository.GetAllAsync();
        foreach (var entity in certificates)
        {
            ResponseCertificate response = new ResponseCertificate(entity.Id,entity.Title,entity.Issuer,entity.IssuedDate,entity.ExpirationDate);
            responseCertificates.Add(response);
        }
        return  responseCertificates;   
    }

    public async Task<ResponseCertificate> GetCertificateById(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        ResponseCertificate response = new ResponseCertificate(entity.Id, entity.Title, entity.Issuer,
            entity.IssuedDate, entity.ExpirationDate);

        return response;
    }

    public async Task<string> EditCertificateById(Guid id, RequestCertificate requestCertificate)
    {
        var result = await repository.UpdateAsync(id, requestCertificate);

        if (result)
        {
            return "Successfully edited!";
        }

        return "Failed to update. ID: " + id;
    }

    public async Task<string> DeleteCertificateById(Guid id)
    {
        var result = await repository.DeleteAsync(id);

        if (result)
        {
            return "Deleted successfully!";
        }

        return "Failed to delete. ID:  " + id;
    }

    public async Task<string> AddCertificate(RequestCertificate requestCertificate)
    {
        var result = await repository.AddAsync(requestCertificate);

        if (result)
        {
            return "Successfully added!";
        }
        return "Failed to add";
    }
}