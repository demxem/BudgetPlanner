using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;

namespace DAL.DbAccess
{
    public class PgsqlAccess : IPgsqlAccess
    {
        private readonly IConfiguration _config;

        public PgsqlAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId = "Default")
        {
            using var cnn = new NpgsqlConnection(_config.GetConnectionString(connectionId));

            return await cnn.QueryAsync<T>(sql, parameters);

        }

        public async Task SafeData<U>(string sql, U parameters, string connectionId = "Default")
        {
            using var cnn = new NpgsqlConnection(_config.GetConnectionString(connectionId));

            await cnn.ExecuteAsync(sql, parameters);
        }
    }
}
