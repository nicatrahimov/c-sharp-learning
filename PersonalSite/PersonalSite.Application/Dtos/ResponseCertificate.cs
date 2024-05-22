namespace PersonalSite.Application.Dtos;

public record ResponseCertificate(Guid id,string Title, string Issuer, DateTime IssuedDate, DateTime? ExpirationDate);