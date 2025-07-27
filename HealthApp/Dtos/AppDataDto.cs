using SQLite;

namespace HealthApp.Dtos
{
    public class AppDataDto
    {
        [PrimaryKey]
        public string Id { get; set; }


        public string Contents { get; set; }
    }
}
