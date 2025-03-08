using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using serverSide.Data;

namespace serverSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Registrar : ControllerBase
    {
        private readonly CDKDbContext _context;
        private readonly CDKPortalContext _portalContext;

        public Registrar(CDKDbContext context, CDKPortalContext portalContext)
        {
            _context = context;
            _portalContext = portalContext;
        }

        [HttpGet("student-list")]
        public IActionResult GetStudentList()
        {
            return Ok(_context.Students.ToList());
        }
    }
}
