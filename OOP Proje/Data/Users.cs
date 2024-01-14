using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Proje.Data
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public  UserType UserType { get; set; }

    }

    public enum UserType
    {
        Admin,
        User,
    }
}
