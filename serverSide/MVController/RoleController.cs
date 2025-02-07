using Microsoft.AspNetCore.Mvc;
using serverSide.Data;

namespace serverSide.MVController
{
    public class RoleController : Controller
    {
        private readonly CDKDbContext _context;
        private readonly CDKPortalContext _portalContext;
        public RoleController(CDKDbContext context, CDKPortalContext portalContext)
        {
            _context = context;
            _portalContext = portalContext;
        }

        //public ActionResult Index() 
        //{
        //    return View(_context.Instructors);
        //}
        //public IActionResult AddRole ()
        //{

        //}
    }
}
