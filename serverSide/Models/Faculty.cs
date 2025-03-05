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
        public string DepartmentName { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string? PortalId { get; set; }
        public ICollection<InstructorCourse>? InstructorCourses { get; set; }
        public ICollection<StudentInstructorEvaluation>? Evaluations { get; set; }
    }
}
