using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    internal class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Email;
        public string Id;


        public Person(string FirstName,string LastName, int Age , string Email,string Id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Age = Age;
            this.Email = Email;
            this.Id = Id;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine($"Firstname: {FirstName} \nLastname: {LastName} \nAge:{Age} \nEmail: {Email} \nId: {Id}");
        }
    }
}
