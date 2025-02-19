using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serverSide.Models
{
    public class Student
    {
        [Key]
        public required string StudentId { get; set; }
        [StringLength(20)]
        public required string Firstname { get; set; }
        [StringLength(20)]
        public required string Middlename { get; set; }
        [StringLength(20)]
        public required string Lastname { get; set; }
        public int? Year { get; set; }
        public string? Status { get; set; }
        public int? SectionId { get; set; }
        public Section? Section { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string? PortalId { get; set; }
        public ICollection<StudentInstructorEvaluation>? Evaluations { get; set; } 
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        [NotMapped]
        public List<Department> ListOfDepatment { get; set; } = new List<Department>();
        [NotMapped]
        public string? DepartmentName { get; set; }
    }
}
