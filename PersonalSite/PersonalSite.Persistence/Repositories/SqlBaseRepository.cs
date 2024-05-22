using System.Collections.Immutable;
using Dapper;
using PersonalSite.Application.Repositories;

namespace PersonalSite.Persistence.Repositories;

public sealed class SqlBaseRepository : ISqlBaseRepository
{
    
    private readonly IDbConnectionFactory _connectionFactory;

    public SqlBaseRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    
    public async Task<ImmutableList<object>> QueryAsync(string sql, DynamicParameters parameters)
    {
        using (var connection = _connectionFactory.CreateConnection())
        { 
            var result = await connection.QueryAsync<object>(sql, parameters);
            var immutableResult = result.ToImmutableList();
            return immutableResult;
        }
    }

    public async Task<object> QueryFirstOrDefaultAsync(string sql, DynamicParameters parameters)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<object>(sql, parameters);
            return result;
        }
    }

    public async Task<bool> ExecuteAsync(string sql, DynamicParameters parameters)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            var rowsAffected = await connection.ExecuteAsync(sql, parameters);
            return rowsAffected > 0;
        }
        
    }

    public async Task<bool> ExecuteScalarAsync(string sql, DynamicParameters parameters)
    {
        using (var connection = _connectionFactory.CreateConnection())
        { 
            var result = await connection.ExecuteScalarAsync(sql, parameters);
            
            return result != null;
        }
    }
    
    // public async Task<bool> ExecuteWithTransactionAsync(string sql, DynamicParameters parameters)
    // {
    //     using (var connection = _connectionFactory.CreateConnection())
    //     {
    //         using (var transaction = connection.BeginTransaction())
    //         {
    //             try
    //             {
    //                 var rowsAffected = await connection.ExecuteAsync(sql, parameters, transaction);
    //                 transaction.Commit();
    //                 return rowsAffected > 0;
    //             }
    //             catch (Exception)
    //             {
    //                 transaction.Rollback();
    //                 return false;
    //             }
    //         }
    //     }
    // }
}




            