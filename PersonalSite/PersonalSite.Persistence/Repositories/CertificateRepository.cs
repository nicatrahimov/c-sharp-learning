using System.Collections.Immutable;
using System.Data;
using Dapper;
using PersonalSite.Application.Dtos;
using PersonalSite.Application.Repositories;
using PersonalSite.Domain.Entities;

namespace PersonalSite.Persistence.Repositories;

public sealed class CertificateRepository: ICertificateRepository
{
    private readonly ISqlBaseRepository _sqlBaseRepository;

    public CertificateRepository(ISqlBaseRepository sqlBaseRepository)
    {
        _sqlBaseRepository = sqlBaseRepository;
    }
    
    public async Task<ImmutableList<Certificate>> GetAllAsync()
    {
        string sql = "SELECT * FROM personal_site.certificate";
        var result = await _sqlBaseRepository.QueryAsync(sql, null);
        var certificates = result.Cast<Certificate>().ToImmutableList();
        return certificates;
    }

    public async Task<Certificate> GetByIdAsync(Guid id)
    {
        string sql = "Select * from personal_site.certificate where ID = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.Guid);

        Certificate result = (Certificate) await _sqlBaseRepository.QueryFirstOrDefaultAsync(sql, parameters);
        
        return result;  
    }

    public async Task<bool> AddAsync(RequestCertificate? request)
    {
        if (request != null)
        {
            string sql = "insert into testapi.product(id, title,issuer ,issued_date, expiration_date) values(@id, @title, @issuer, @issued_date, @expiration_date)";
            var parameters = new DynamicParameters();
            parameters.Add("id",Guid.NewGuid());
            parameters.Add("title",request.Title);
            parameters.Add("issuer", request.Issuer);
            parameters.Add("issued_date",request.IssuedDate);
            parameters.Add("expiration_date", request.ExpirationDate);

            return await _sqlBaseRepository.ExecuteAsync(sql, parameters);
        }
        return false;
    }

    public async Task<bool> UpdateAsync(Guid id,RequestCertificate request)
    {
            string sql = "UPDATE personal_site.certificate SET";
            var parameters = new DynamicParameters();
        
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                sql += "title = @title, ";
                parameters.Add("title", request.Title);
            }
            if (!string.IsNullOrWhiteSpace(request.Issuer))
            {
                sql += "issuer = @issuer, ";
                parameters.Add("issuer",request.Issuer);
            }
            if (request.IssuedDate != null )
            {
                sql += "issued_date = @issued_date, ";
                parameters.Add("issued_date", request.IssuedDate);
            }

            if (request.ExpirationDate != null)
            {
                sql += "expiration_date = @expiration_date, ";
                parameters.Add("expiration_date", request.ExpirationDate);
            }

            sql = sql.TrimEnd(' ', ',');
            sql += " WHERE id = @id";
            parameters.Add("id", id);

            return await _sqlBaseRepository.ExecuteAsync(sql, parameters);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        string sql = "DELETE from personal_site where id=@id";
        var parameters = new DynamicParameters();
        parameters.Add(sql, id);
        var result = await _sqlBaseRepository.ExecuteAsync(sql, parameters);
        return result;
    }
}