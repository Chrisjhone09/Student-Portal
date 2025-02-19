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
        public async Task<IActionResult> GetStudentProfile()
        {
            
                //var userClaim = User.FindFirst(ClaimTypes.Role)?.Value;
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized("Invalid token or missing student ID claim.");
                }

                //var getStudent = _context.Students.FirstOrDefault(s => s.PortalId == userId);
                //if (getStudent == null)
                //{
                //    return NotFound("Student not found.");
                //}

                //var sectionId = getStudent.SectionId;
                //if (sectionId == null)
                //{
                //    return NotFound("Student is not assigned to a section.");
                //}

                var schedules = new List<Schedule>
                {
                    new Schedule { Start = "08:00 AM", End = "09:30 AM", Day = "Monday", Room = "Room 101", CourseName = "Mathematics" },
                    new Schedule { Start = "10:00 AM", End = "11:30 AM", Day = "Monday", Room = "Room 202", CourseName = "Physics" },
                    new Schedule { Start = "01:00 PM", End = "02:30 PM", Day = "Tuesday", Room = "Room 303", CourseName = "Chemistry" },
                    new Schedule { Start = "03:00 PM", End = "04:30 PM", Day = "Wednesday", Room = "Room 404", CourseName = "Biology" },
                    new Schedule { Start = "08:30 AM", End = "10:00 AM", Day = "Thursday", Room = "Room 105", CourseName = "History" },
                    new Schedule { Start = "11:00 AM", End = "12:30 PM", Day = "Friday", Room = "Room 206", CourseName = "English Literature" },
                    new Schedule { Start = "02:00 PM", End = "03:30 PM", Day = "Friday", Room = "Room 307", CourseName = "Computer Science" }
                 };



            return Ok(schedules);
            
        }

    }
}
