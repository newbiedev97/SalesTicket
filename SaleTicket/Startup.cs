using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SaleTicket.Models;

[assembly: OwinStartupAttribute(typeof(SaleTicket.Startup))]
namespace SaleTicket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleAndUser();
        }

        public void CreateRoleAndUser()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleMgr.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleMgr.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Admin1";
                user.Email = "Admin1@Gmail.com";
                string pw = "Admin@123";
                var newUSer = userMgr.Create(user, pw);
                if(newUSer.Succeeded)
                {
                    var result = userMgr.AddToRole(user.Id, "Admin");
                }

            }

        }
    }
}
