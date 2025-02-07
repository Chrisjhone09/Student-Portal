namespace server.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan Start  { get; set; }
        public TimeSpan End { get; set; }
        public string Room { get; set; }
    }
}
