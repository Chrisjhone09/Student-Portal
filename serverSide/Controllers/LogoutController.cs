using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using serverSide.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : Controller
    {
        private readonly SignInManager<User> _signinManager;

        public LogoutController(SignInManager<User> signinManager) 
        {
            this._signinManager = signinManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout([FromBody] object empty)
        {
            try
            {
                if (empty != null)
                {
                    await _signinManager.SignOutAsync();
                    return Ok(new { message = "Logout successful" });
                }
                return Unauthorized(new { message = "Invalid request" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during logout: {ex.Message}");
                return StatusCode(500, new { error = "An error occurred during logout" });
            }
        }


    }
}
