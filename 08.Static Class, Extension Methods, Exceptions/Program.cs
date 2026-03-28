using _08.Static_Class__Extension_Methods__Exceptions.Models;
using _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions;

namespace _08.Static_Class__Extension_Methods__Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginSystem newlogin1 = new LoginSystem();

            bool a = false;

            while(!a)
            {
                try
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine()?.Trim().ToLower();  // trim ve lower methodlarindan istifade etdimki daha sehvsiz olsun.
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine()?.Trim();  //Password-da hem boyuk hem de kicik herfler ola biler deye lower istifade etmedim.
                    a = newlogin1.Login(username, password);
                }catch(InvalidUsernameException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }catch(InvalidPasswordException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }catch (UserNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    foreach (var item in newlogin1._users)
                    {
                        Console.WriteLine(item.Username);
                    }
                }catch(IncorrectPasswordException ex)
                {
                    Console.WriteLine("Warning: " + ex.Message);
                }catch(AccountLockedException ex)
                {
                    Console.WriteLine("CRITICAL: " + ex.Message + " contact admin");
                    break;
                }catch(Exception ex)
                {
                    Console.WriteLine("UNEXPECTED ERROR: "+ ex.Message);
                }
                
            }

            
        }
    }
}
