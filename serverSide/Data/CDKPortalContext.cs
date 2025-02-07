using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using serverSide.Models;

namespace serverSide.Data
{
    public class CDKPortalContext : IdentityDbContext<User>
    {

        public CDKPortalContext(DbContextOptions<CDKPortalContext> options)
            : base(options)
        {

        }

    }

}
