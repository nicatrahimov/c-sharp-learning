namespace PersonalSite.Application.Dtos;

public record RequestCertificate(string Title, string Issuer, DateTime IssuedDate, DateTime? ExpirationDate);