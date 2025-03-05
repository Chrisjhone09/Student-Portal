namespace serverSide.Models
{
    public class InstructorCourse
    {
        public string FacultyId { get; set; }
        public Faculty Instructor { get; set; }
        public Course Course { get; set; }
        public string CourseId { get; set; }
    }
}
