using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace serverSide.Models
{
    public class Course
    {
        [Key]
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int Credits { get; set; }
        public int Units { get; set; }
        public string? PrerequisiteFrom { get; set; }
        public string? PrerequisiteTo { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public int? DepartmentId { get; set; }
        public int? Year { get; set; }
        public int? Semester { get; set; }
        public ICollection<Schedule>? Schedule { get; set; }
        public ICollection<InstructorCourse>? InstructorCourses { get; set; }

    }

}
