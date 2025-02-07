namespace server.Models
{
    public class Instructor
    {
        public ICollection<Course> HandledCourses { get; set; }
    }
}
