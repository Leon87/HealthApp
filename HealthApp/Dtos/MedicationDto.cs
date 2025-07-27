using SQLite;

namespace HealthApp.Dtos
{
    public class MedicationDto
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Index { get; set; }

        public int Name { get; set; }

        public DateTime? TimeTaken { get; set; }
        public DateTime? NextDue { get; set; }
    }
}
