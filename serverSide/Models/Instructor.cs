using System.ComponentModel.DataAnnotations;

namespace serverSide.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Course? Course { get; set; }
        public Schedule? Schedule { get; set; }
        public int? ScheduleId { get; set; }
        public string PortalId { get; set; }
        public ICollection<StudentInstructorEvaluation>? Evaluations { get; set; }

    }
}