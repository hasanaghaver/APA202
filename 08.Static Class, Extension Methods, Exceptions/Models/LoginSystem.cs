using _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _08.Static_Class__Extension_Methods__Exceptions.Models
{
    internal class LoginSystem
    {
        public User[] _users;
        private const int MaxAttempts = 3;

        public LoginSystem()
        {
            _users = new User[] { new User("admin", "admin123"), new User("student", "student123"), new User("teacher", "teacher123") };
        }
        
        public void ValidateUsername(string username)
        {
            if (username == null || username.Trim().Length < 3)
            {
                throw new InvalidUsernameException();
            }
        }

        public void ValidatePassword(string password)
        {
            if(password == null||password.Trim().Length < 6)
            {
                throw new InvalidPasswordException();
            }
        }
        private User FindUser(string username)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (username.ToLower() == _users[i].Username.ToLower())
                {
                    return _users[i];
                }
            }
            return null;
        }
        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);
            User selectedUser = FindUser(username);
            if (selectedUser==null)
            {
                throw new UserNotFoundException();
            }
            if (selectedUser.IsLocked== true)
            {
                throw new AccountLockedException();
            }
            if (password == selectedUser.Password) 
            {
                selectedUser.FailedAttemps = 0;
                Console.WriteLine($"Login successful! Welcome, {username}!");
                return true;
            }
            else
            {
                selectedUser.FailedAttemps++;
                if (selectedUser.FailedAttemps < MaxAttempts)
                {
                    throw new IncorrectPasswordException(MaxAttempts-selectedUser.FailedAttemps);
                }
                else
                {
                    selectedUser.IsLocked = true;
                    throw new AccountLockedException();
                }
            }
            
        }
    }

}
