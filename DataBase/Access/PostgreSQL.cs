using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DataBase.Access;

public class PostgreSQL : IPostgreSQL
{
    private readonly IConfiguration _config;

    public PostgreSQL(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, UParameters>(string sql, UParameters parameters)
    {
        using var cnn = new NpgsqlConnection(_config.GetConnectionString(Helper.ConnectionString));

        return await cnn.QueryAsync<T>(sql, parameters);
    }

    public async Task<IEnumerable<TResult>> LoadData<TFirst, TSecond, TResult, UParameters>(string sql, Func<TFirst, TSecond, TResult> map, UParameters parameters)
    {
        using var cnn = new NpgsqlConnection(_config.GetConnectionString(Helper.ConnectionString));

        return await cnn.QueryAsync(sql, map, parameters);
    }

    public async Task<IEnumerable<TResult>> LoadData<TFirst, TSecond, TThird, TForth, TResult, UParameters>(string sql, Func<TFirst, TSecond, TThird, TForth, TResult> map, UParameters parameters)
    {
        using var cnn = new NpgsqlConnection(_config.GetConnectionString(Helper.ConnectionString));

        return await cnn.QueryAsync(sql, map, parameters);
    }

    public async Task SafeData<UParameters>(string sql, UParameters parameters)
    {
        using var cnn = new NpgsqlConnection(_config.GetConnectionString(Helper.ConnectionString));

        await cnn.ExecuteAsync(sql, parameters);
    }
}

