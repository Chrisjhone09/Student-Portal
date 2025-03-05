namespace serverSide.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int NumberOfEnrolledStudents { get; set; }
        public int NumberOfInstructors { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
    }
}
