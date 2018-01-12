using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProcess.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public string UserAddress { get; set; }

    }
}