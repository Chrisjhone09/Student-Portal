using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serverSide.Data;
using serverSide.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverSide.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly CDKDbContext _context;

        public EvaluationController(CDKDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("instructors")]
        public async Task<IActionResult> GetInstructorsList()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            var getUserStudent = await _context.Students
                .FirstOrDefaultAsync(s => s.PortalId == userId);

            if (getUserStudent == null)
            {
                return NotFound("Student not found");
            }

            var getAllInstructorsId = await _context.StudentCourses
                .Where(sc => sc.StudentId == getUserStudent.StudentId)
                .Select(sc => sc.FacultyId)
                .ToListAsync();

            //var listOfInstructors = await _context.Instructors
            //    .Where(i => getAllInstructorsId.Contains(i.InstructorId))
            //    .ToListAsync();

            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetInstructorEvaluationForm(string id)
        {
            var getInstructor = _context.Faculty
                .FirstOrDefault(i => i.FacultyId == id);
            return Ok();
        }


        [HttpPost("submit")]
        public IActionResult SubmitFeedback([FromBody] EvaluationResponse feedback)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var getStudent = _context.Students
                .FirstOrDefault(s => s.PortalId == userId)!;

            var evaluation = new Evaluation
            {
                Feedback = feedback.Feedback,
                Rating = feedback.Rating
            };


            _context.Evaluations.Add(evaluation);
            _context.SaveChanges();

            var evaluationID = evaluation.EvaluationId;


            var instructorEvaluation = new StudentInstructorEvaluation
            {
                EvaluationId = evaluationID,
                FacultyId = feedback.FacultyId,
                StudentId = getStudent.StudentId
            };

            if(instructorEvaluation == null)
            {
                return BadRequest("Invalid instructor ID");
            }

            _context.StudentInstructorEvaluations.Add(instructorEvaluation);
            _context.SaveChanges();




            return Ok("Evaluation submitted successfully");
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
