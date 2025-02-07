using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Course
    {
        [Key]
        public int CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public double? Grade { get; set; }
        public string Year { get; set; }
        public double? Prelim { get; set; }
        public double? Midterm { get; set; }
        public double? Final { get; set; }
        public int Credits { get; set; }
        public int Units { get; set; }
        public string PrerequisiteFrom { get; set; }
        public string PrerequisiteTo { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public string UserId { get; set; }
        public ICollection<PortalUser> Students { get; set; }
        public PortalUser User { get; set; }

    }
}
