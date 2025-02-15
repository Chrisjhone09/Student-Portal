using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using server.Models;
using serverSide.Data;
using serverSide.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CDKPortalContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;  

        public LoginController(IConfiguration configuration, CDKPortalContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _configuration = configuration;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            Console.WriteLine($"Email: {model.CDKemail}, Password: {model.Password}");

            if (!ModelState.IsValid || model == null)
                return BadRequest("Invalid login request.");

            var user = await _userManager.FindByEmailAsync(model.CDKemail);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
            if (!passwordCheck.Succeeded)
                return Unauthorized("Invalid email or password.");

            var secretKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(secretKey))
                return StatusCode(500, "JWT secret key is not configured.");

            var token = JwtTokenGenerator.GenerateToken(user.Email, secretKey, 30, user.Id);

            var student = new User
            {
                Firstname = user.Firstname,
                UserName = user.UserName,
                Email = user.Email,
                Middlename = user.Middlename,
                Lastname = user.Lastname,
                Token = token,
                Program = user.Program,
            };

            return Ok(student);
        }


    }
}
