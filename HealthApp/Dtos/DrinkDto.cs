using SQLite;

namespace HealthApp.Dtos
{
    public class DrinkDto
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Consumed { get; set; }
    }
}
