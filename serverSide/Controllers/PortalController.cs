using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using serverSide.Data;
using serverSide.Models;

namespace serverSide.Controllers
{
    [Route("api/portal")]
    [ApiController]
    public class PortalController : ControllerBase
    {
        private readonly CDKDbContext _context;

        public PortalController(CDKDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentProfile()
        {
            try
            {
                var userClaim = User.FindFirst(ClaimTypes.Name)?.Value; 
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userClaim == null)
                {
                    return Unauthorized("Invalid token or missing student ID claim.");
                }

                var getStudent = await _context.Students.FindAsync(userId);
                if (getStudent == null)
                {
                    return NotFound("Student not found.");
                }

                var sectionId = getStudent.SectionId;
                if (sectionId == null)
                {
                    return NotFound("Student is not assigned to a section.");
                }

                var getSchedule = await _context.Schedules.FindAsync(sectionId);
                if (getSchedule == null)
                {
                    return NotFound("Schedule not found.");
                }

                return Ok(getSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
