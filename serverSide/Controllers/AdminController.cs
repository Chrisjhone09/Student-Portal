using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public AdminController(CDKDbContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
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

            _context.Faculty.Add(new Faculty
            {
                FacultyId = id,
                FirstName = faculty.FirstName,
                LastName = faculty.LastName,
                MiddleName = faculty.MiddleName,
                DepartmentName = faculty.DepartmentName,
                Role = faculty.Role
            });

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("faculty-list")]
        public IActionResult GetFacultyList()
        {
            return Ok(_context.Faculty.ToList());
        }


    }
}
