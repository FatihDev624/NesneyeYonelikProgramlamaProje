using OOP_Proje.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Proje.BL
{
    class UserBL
    {
        private List<Users> usersList;

        public UserBL()
        {
            // Örnek kullanıcılar
            usersList = new List<Users>
        {
            new Users { UserName = "fatih624", Password = "123", UserType = UserType.Admin },
            new Users { UserName = "user", Password = "user123", UserType = UserType.User }
        };
        }

        public Users login(string username, string password)
        {

            // Kullanıcı adını ve şifreyi kontrol ediyor
            Users loggedInUser = usersList.Find(x => x.UserName == username && x.Password == password);

            return loggedInUser;
        }
    }
}
