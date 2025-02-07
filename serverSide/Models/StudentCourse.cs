namespace serverSide.Models
{
    public class StudentCourse
    {
        public string? StudentId { get; set; }
        public Student? Student { get; set; }
        public string? CourseId { get; set; }
        public Course? Course { get; set; }
        public int? ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }
        public int? SectionId { get; set; }
        public Section? Section { get; set; }
        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentID { get; set; }
        public int? Prelim { get; set; }
        public int? Midterm { get; set; }
        public int? Final { get; set; }
        public int? GPA { get; set; }

    }
}