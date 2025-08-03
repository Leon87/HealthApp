using HealthApp.Dtos;
using HealthApp.Shared;

public class DataCrudOperations<T> where T : class, new()
{

    SqlLiteConnectionFactory _connectionFactory;

    public DataCrudOperations(SqlLiteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;

    }

    public async Task<List<T>> GetAllAsync(string dataType = "")
    {
        var db = _connectionFactory.CreateConnection();

        var data = await db.Table<T>().ToListAsync();
        //var data = await db.GetAsync<T>(dataType);
        return data;
    }

    public async Task<AppDataDto> GetAllKeysAsync(string dataType = "")
    {
        var db = _connectionFactory.CreateConnection();

        var data = await db.Table<AppDataDto>().ToListAsync();
        //var data = await db.GetAsync<T>(dataType);
        return data.Where(x => x.Id == dataType).First();
    }

    // ...repeat the process for the other CRUD-related methods,
    // in the same generic way.
}