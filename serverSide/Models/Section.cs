using System.ComponentModel.DataAnnotations.Schema;

namespace serverSide.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string? SectionName { get; set; }
        public int? StudentCount { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public int? DepartmentId { get; set; }
        public Course? Course { get; set; }
        public string? CourseId { get; set; }
        public int Year { get; set; }
        public ICollection<Schedule>? Schedule { get; set; } 
        public Department? Department { get; set; }
        [NotMapped]
        public List<Student> ListOfStudents { get; set; } = new List<Student>();
        [NotMapped]
        public Section? SectionObj { get; set; }
        public List<Department>? ListOfDepartments { get; internal set; }
    }
}
