using serverSide.Models;

namespace serverSide.DTO
{
    public class FacultyListAndCount
    {
        public List<Faculty> Faculties { get; set; } = new List<Faculty>();
        public int StudentCount { get; set; }
        public int UserCount { get; set; }
        public int FacultyCount { get; set; }
        public int DepartmentCount { get; internal set; }
    }
}
