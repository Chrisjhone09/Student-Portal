using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serverSide.CommonUtilities;
using serverSide.Data;
using serverSide.DTO;
using serverSide.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly CDKDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly CDKPortalContext _portalContext;

        public AdminController(CDKDbContext context, RoleManager<IdentityRole> roleManager,
                                UserManager<User> userManager, CDKPortalContext portalContext)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _portalContext = portalContext;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("add-faculty")]
        public async Task<IActionResult> AddFaculty([FromBody] FacultyDTO faculty)
        {

            if (!await _roleManager.RoleExistsAsync(faculty.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(faculty.Role));
            }

            string id = IdGenerator.GenerateId();
            var programId = _context.AcademicPrograms.FirstOrDefault(p => p.ProgramName == faculty.departmentName)!.ProgramId;


            _context.Faculty.Add(new Faculty
            {
                FacultyId = id,
                FirstName = faculty.FirstName,
                LastName = faculty.LastName,
                MiddleName = faculty.MiddleName,
                ProgramId = programId,
                Role = faculty.Role
            });

            var academicProgram = await _context.AcademicPrograms.FindAsync(programId);
            academicProgram!.NumberOfFaculty++;
            await _context.SaveChangesAsync();

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("faculty-list")]
        public IActionResult GetFacultyList()
        {
            var facultyList = _context.Faculty.ToList();

            var obj = new FacultyListAndCount
            {
                Faculties = facultyList,
                StudentCount = _context.Students.Count(),
                UserCount = _portalContext.Users.Count(),
                FacultyCount = _context.Faculty.Count(),
                DepartmentCount = _context.AcademicPrograms.Count()
            };


            return Ok(obj);
        }

        [HttpGet("student-list")]
        public IActionResult GetStudentList()
        {
            return Ok(_context.Students.ToList());
        }


        [HttpGet("user-list")]
        public IActionResult GetUserList()
        {
            return Ok(_portalContext.Users.ToList());
        }

        [HttpGet("program-list")]
        public IActionResult GetAcademicProgramList()
        {
            return Ok(_context.AcademicPrograms.ToList());
        }

        [HttpPost("create-program")]
        public IActionResult CreateDepartment([FromBody] DepartmentWithHeadDTO obj)
        {

            var headName = _context.Faculty.Find(obj.FacultyId);

            var acadProgram = new AcademicProgram
            {
                ProgramName = obj.DepartmentName,
                HeadName = headName?.FirstName + " " + headName?.LastName
            };
            _context.Add(acadProgram);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("faculty-details/{id}")]
        public IActionResult ViewFacultyDetails(string id)
        {
            return Ok(_context.Faculty.Find(id));
        }
        [HttpPut("update-faculty/{facultyId}")]
        public IActionResult UpdateFaculty([FromBody] Faculty faculty)
        {
            return Ok();

        }
    }
}
