using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<PortalUser> _userManager;

        public RegisterController(UserManager<PortalUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if (model == null)
                return BadRequest("Invalid user data.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
                return Conflict("A user with the same email already exists.");

            var user = new PortalUser
            {
                UserName = model.Email,
                Firstname = model.FirstName,
                Middlename = model.MiddleName,
                Lastname = model.LastName,
                Program = model.Program,
                Email = model.Email,
                LockoutEnabled = false,
                StudentId = model.StudentId,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Registration successful." });
            }

            return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
        }
    }
}
