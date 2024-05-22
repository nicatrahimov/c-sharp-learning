using Microsoft.AspNetCore.Mvc;
using PersonalSite.Application.Dtos;
using PersonalSite.Application.Services.CertificateService;

namespace PersonalSite.Api.Controllers;

[ApiController]
[Route("api/v1/certificates")]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _service;

    public CertificateController(ICertificateService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCertificates()
    {
        List<ResponseCertificate> allCertificates = await _service.GetAllCertificates();

        return Ok(allCertificates);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCertificateById(Guid id)
    {
        var certificate = await _service.GetCertificateById(id);

        return Ok(certificate);
    }
}