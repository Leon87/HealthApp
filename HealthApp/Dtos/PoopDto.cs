using SQLite;

namespace HealthApp.Dtos
{
    public class PoopDto
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public int StoolType { get; set; }
        public DateTime PooTime { get; set; }
    }
}
