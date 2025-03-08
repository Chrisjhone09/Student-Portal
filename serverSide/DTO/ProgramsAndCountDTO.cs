using serverSide.Models;

namespace serverSide.DTO
{
    public class ProgramsAndCountDTO
    {
        public ICollection<AcademicProgram> Programs{ get; set; }
        public int? NumberOfPrograms { get; set; }
    }
}
