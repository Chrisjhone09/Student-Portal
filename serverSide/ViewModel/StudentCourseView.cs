using serverSide.Models;

namespace serverSide.ViewModel
{
    public class StudentCourseView
    {
        public Department Department { get; set; } = new Department();
        public Student? Student { get; set; }
        public List<Course> ListOfCourses { get; set; } = new List<Course>();
        public List<Student> ListOfStudent { get; set; } = new List<Student>();
        public List<Instructor> ListOfInstructors { get; set; } = new List<Instructor>();
        public int? DepartmentId { get; set; }
        public int StudentId { get; set; }
    }
}
