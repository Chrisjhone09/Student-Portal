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
        public Faculty? Instructor { get; set; }
        public string? FacultyId { get; set; }
        public Course? Course { get; set; }
        public string? CourseId { get; set; }
        [NotMapped]
        public string? CourseName { get; set; }
        public StudentCourse? StudentCourse { get; set; }

    }
}
