

using System.ComponentModel.DataAnnotations.Schema;

namespace serverSide.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? StudentCount { get; set; } = 0;
        public ICollection<Section>? Sections { get; set; } = new List<Section>();
        public ICollection<Student>? Students { get; set; } = new List<Student>();
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<Course>? Courses { get; set; }
    }
}
