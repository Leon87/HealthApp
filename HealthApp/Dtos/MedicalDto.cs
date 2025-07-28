using SQLite;

namespace HealthApp.Dtos
{
    public class MedicalDto
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Issue { get; set; }
        public DateTime Consumed { get; set; }
        public int Serverity { get; set; }
    }
}
