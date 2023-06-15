namespace DAL.DbAccess
{
    public interface IPgsqlAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId = "Default");

        Task SafeData<U>(string sql, U parameters, string connectionId = "Default");

    }
}