namespace PersonalSite.Domain.Entities;

public sealed class Certificate
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Issuer { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
}