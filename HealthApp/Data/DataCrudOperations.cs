using HealthApp.Shared;

public class DataCrudOperations<T> where T : class, new()
{

    SqlLiteConnectionFactory _connectionFactory;

    public DataCrudOperations(SqlLiteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;

    }

    public async Task<List<T>> GetAllAsync()
    {
        var db = _connectionFactory.CreateConnection();
        var data = await db.Table<T>().ToListAsync();
        return data;
    }

    // ...repeat the process for the other CRUD-related methods,
    // in the same generic way.
}