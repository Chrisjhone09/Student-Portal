using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using serverSide.Data;
using serverSide.Models;

namespace serverSide.Controllers
{
    [Authorize]
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
        public IActionResult GetStudentProfile()
        {
            
                //var userClaim = User.FindFirst(ClaimTypes.Role)?.Value;
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized("Invalid token or missing student ID claim.");
                }

            var getStudent =  _context.Students.FirstOrDefault(s => s.PortalId == userId);
            if (getStudent == null)
            {
                return NotFound("Student not found.");
            }

            //var sectionId = getStudent.SectionId;
            //if (sectionId == null)
            //{
            //    return NotFound("Student is not assigned to a section.");
            //}


            //var getSchedules = _context.Schedules.Where(s => s.SectionId == sectionId).ToList();


            return Ok();
            
        }

    }
}
