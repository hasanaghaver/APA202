using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions
{
    internal class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; set; }
        public static string defaultMessage = "Password is incorrect";
        public IncorrectPasswordException():base(defaultMessage) { }

        public IncorrectPasswordException(int attemptsLeft):base($"Incorrect password. You have {attemptsLeft} atempt")
        {
            AttemptsLeft = attemptsLeft;
        }
    }
}
