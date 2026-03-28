using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions
{
    internal class InvalidPasswordException: Exception
    {
        public static string defaultMessage = "Password is to short or empty";

        public InvalidPasswordException() : base(defaultMessage) { }
        public InvalidPasswordException(string message): base(message) { }

    }
}
