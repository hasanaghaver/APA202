using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public static string defaultMessage = "User not found";

        public UserNotFoundException():base(defaultMessage) { }

        public UserNotFoundException(string username):base($"{username} not found") { }
    }
}
