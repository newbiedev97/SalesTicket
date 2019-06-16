using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//For Admin to See USer Info From Database
namespace TicketViewModel.UserViewModel
{
    public class UserInfoViewModel
    {
        public string userID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public bool EmailConfirm { get; set; }
        public string RoleName { get; set; }
    }
}
