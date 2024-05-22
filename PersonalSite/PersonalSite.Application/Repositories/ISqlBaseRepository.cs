using System.Collections.Immutable;
using Dapper;

namespace PersonalSite.Application.Repositories;

public interface ISqlBaseRepository
{
    Task<ImmutableList<object>> QueryAsync(string sql, DynamicParameters parameters);
    Task<object> QueryFirstOrDefaultAsync(string sql, DynamicParameters pramaeters);
    Task<bool> ExecuteAsync(string sql, DynamicParameters parameters);   
    Task<bool> ExecuteScalarAsync(string sql, DynamicParameters parameters);
}   