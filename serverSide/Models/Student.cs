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
        public string? PortalId { get; set; }
        public ICollection<StudentInstructorEvaluation>? Evaluations { get; set; } 
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public AcademicProgram? Program { get; set; }
        public int? ProgramId { get; set; }

    }
}
