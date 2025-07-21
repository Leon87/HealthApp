using SQLite;

namespace HealthApp.Dtos
{
    public class FoodDto
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Index { get; set; }
        public string? Food { get; set; }
        public DateTime Consumed { get; set; }
        public string? Amount { get; set; }
    }
}
