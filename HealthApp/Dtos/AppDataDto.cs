using SQLite;

namespace HealthApp.Dtos
{
    public class AppDataDto
    {
        [PrimaryKey]
        public string Index { get; set; }

        public List<string> Contents { get; set; }
    }
}
