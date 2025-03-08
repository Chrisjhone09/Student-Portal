using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace serverSide.Models
{
    public class Faculty
    {
        public string FacultyId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string? PortalId { get; set; }
        public int? ProgramId { get; set; }
        public AcademicProgram? Program { get; set; }
        public ICollection<InstructorCourse>? InstructorCourses { get; set; }
        public ICollection<StudentInstructorEvaluation>? Evaluations { get; set; }
    }
}
