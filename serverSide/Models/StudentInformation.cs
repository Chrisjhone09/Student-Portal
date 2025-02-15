namespace serverSide.Models
{
    public class StudentInformation
    {
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public Student Student { get; set; }
        
    }
}
