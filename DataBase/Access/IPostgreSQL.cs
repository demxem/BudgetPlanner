namespace DataBase.Access;

public interface IPostgreSQL
{
    Task<IEnumerable<T>> LoadData<T, UParameters>(string sql, UParameters parameters);
    Task<IEnumerable<TResult>> LoadData<TFirst, TSecond, TResult, UParameters>(string sql, Func<TFirst, TSecond, TResult> map, UParameters parameters);
    Task<IEnumerable<TResult>> LoadData<TFirst, TSecond, TThird, TForth, TResult, UParameters>(string sql, Func<TFirst, TSecond, TThird, TForth, TResult> map, UParameters parameters);
    Task SafeData<UParameters>(string sql, UParameters parameters);
}