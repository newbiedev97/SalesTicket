using SaleTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketViewModel.UserViewModel;

namespace SaleTicket.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUser()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var usersWithRoles = (from user in db.Users
                                  select new
                                  {
                                      UserID = user.Id,
                                      UserName = user.UserName,
                                      Email = user.Email,
                                      EmailConfirm = user.EmailConfirmed,
                                      RoleName = (from userRole in user.Roles join role in db.Roles on userRole.RoleId equals role.Id select role.Name).ToList()

                                  }).ToList().Select(u => new UserInfoViewModel()
                                  {
                                      userID = u.UserID,
                                      UserName = u.UserName,
                                      Email = u.Email,
                                      EmailConfirm = u.EmailConfirm,
                                      RoleName=string.Join(",",u.RoleName)
                                  }
            );


            return PartialView(usersWithRoles);
        }

        public ActionResult GetAllRole()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roles = db.Roles.ToList();
            return PartialView(roles);
        }


        public ActionResult CrateUser()
        {
            return PartialView();
        }
    }
}