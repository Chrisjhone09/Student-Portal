using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using server.Data;
using server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CDKPortalContext _context;
        private readonly SignInManager<PortalUser> _signInManager;
        private readonly UserManager<PortalUser> _userManager;  

        public LoginController(IConfiguration configuration, CDKPortalContext context, SignInManager<PortalUser> signInManager, UserManager<PortalUser> userManager)
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

            var token = JwtTokenGenerator.GenerateToken(user.Email, secretKey, 30); 
            return Ok(new { Token = token });
        }


    }
}
