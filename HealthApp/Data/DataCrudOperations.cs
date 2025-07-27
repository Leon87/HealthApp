using HealthApp.Dtos;
using HealthApp.Shared;

namespace HealthApp.Data
{
    public class DataCrudOperations
    {
        private readonly SqlLiteConnectionFactory _connectionFactory;

        public DataCrudOperations(SqlLiteConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<object> GetDataAsync(string tableName)
        {
            var db = _connectionFactory.CreateConnection();
            try
            {
                var dbinfo = await db.GetAsync<AppDataDto>(tableName);
                return dbinfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }


    }
}
