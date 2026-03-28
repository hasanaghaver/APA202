using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Static_Class__Extension_Methods__Exceptions.Models
{
    internal class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public int FailedAttemps { get; set; }

        public User(string userName,string password)
        {
            Username = userName;
            Password = password;
            IsLocked = false;
            FailedAttemps = 0;
        }
    }
}
