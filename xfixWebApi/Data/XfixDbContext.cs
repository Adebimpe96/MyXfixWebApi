using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using xfixWebApi.Models;

namespace xfixWebApi.Data
{
    public class XfixDbContext:IdentityDbContext<ApplicationUser>
    {

        public XfixDbContext(DbContextOptions<XfixDbContext> options) : base(options)
        {

        }
    }
}
