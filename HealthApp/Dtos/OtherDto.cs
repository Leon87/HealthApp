using SQLite;

namespace HealthApp.Dtos
{
    public class OtherDto
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Description { get; set; }
        public string Description2 { get; set; }
    }
}
