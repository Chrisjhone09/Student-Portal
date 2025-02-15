using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using serverSide.Data;
using serverSide.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly CDKDbContext _dbContext;
        

        public RegisterController(UserManager<User> userManager, CDKDbContext context)
        {
            _userManager = userManager;
            _dbContext = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            var isStudentEnrolled = _dbContext.Students.Any(s=> s.StudentId == model.StudentId);
            if (model == null)
                return BadRequest("Invalid user data.");
           

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (isStudentEnrolled) 
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                    return Conflict("A user with the same email already exists.");

                var user = new User
                {
                    UserName = model.Email,
                    Firstname = model.FirstName,
                    Middlename = model.MiddleName,
                    Lastname = model.LastName,
                    Email = model.Email,
                    LockoutEnabled = false,
                    StudentId = model.StudentId,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var portalId = user.Id;

                    var getExistingStudent = _dbContext.Students.FirstOrDefault(s => s.StudentId == model.StudentId);
                    if (getExistingStudent != null)
                    {
                        // Assign the PortalId to the student
                        getExistingStudent.PortalId = portalId;

                        // Update the student record in the database
                        _dbContext.Students.Update(getExistingStudent);
                        await _dbContext.SaveChangesAsync();

                        return Ok(new { message = "Registration successful." });
                    }
                    else
                    {
                        // If the student record is not found, handle the error
                        return BadRequest(new { message = "Student record not found." });
                    }
                }
            }
            
            return BadRequest();
        }
    }
}
