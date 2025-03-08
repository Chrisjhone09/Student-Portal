using System.ComponentModel.DataAnnotations;

namespace serverSide.Models
{
    public class AcademicProgram
    {
        [Key]
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public ICollection<Faculty>? Faculties { get; set; }
        public ICollection<Student>? Students { get; set; }
        public string? HeadName { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfFaculty { get; set; }


    }
}
