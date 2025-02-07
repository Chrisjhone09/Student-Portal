using Microsoft.EntityFrameworkCore;
using serverSide.Data;
using serverSide.Models;
namespace serverSide.CommonUtilities
{
    public class SharedFunction
    {
        private readonly CDKDbContext _context;
        public SharedFunction(CDKDbContext context)
        {
            this._context = context;
        }
        

        private readonly char[] letters = new char[10] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        

        public string GenerateSectionName(int departmentId, int? year)
        {
            var department =_context.Department.Find(departmentId) ;
            var getAllDepartment = _context.Department.ToList();
            string course = string.Empty;
            if (department!.DepartmentName == "Information Technology")
            {
                course = "BSIT";
            }
            else if (department.DepartmentName == "Education")
            {
                course = "BSEd";
            }
            else if (department.DepartmentName == "Hospitality Management")
            {
                course = "BSHM";
            }
            else if (department.DepartmentName == "Criminology")
            {
                course = "BSCrim";
            }
            else
            {
                course = "BSN";
            }

            return $"{course}-{year}";
        }


    }
}
