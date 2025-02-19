using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace serverSide.Models
{
    public class Schedule
    {
        public int? ScheduleId { get; set; }
        public string Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string? Room { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public Section? Section { get; set; }
        public int? SectionId { get; set; }
        public Instructor? Instructor { get; set; }
        public int? InstructorId { get; set; }
        public Course? Course { get; set; }
        public string? CourseId { get; set; }
        [NotMapped]
        public string CourseName { get; set; }

    }
}
