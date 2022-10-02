using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCucan2
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            Balance = 0;
        }

        public User()
        {

        }
    }
}
