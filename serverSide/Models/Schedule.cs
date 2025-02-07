using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace serverSide.Models
{
    public class Schedule
    {
        public int? ScheduleId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Room { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public Section? Section { get; set; }
        public int? SectionId { get; set; }
        public Instructor? Instructor { get; set; }
        public int? InstructorId { get; set; }
        public Course Course { get; set; }
        public string CourseId { get; set; }

    }
}
