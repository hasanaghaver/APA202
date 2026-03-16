using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    internal class Teacher:Person
    {
        public string Department;
        public string MainSubject;
        public decimal BaseSalary;
        public int ExperienceYears;

        public Teacher(string FirstName, string LastName, int Age, string Email, string Id, 
            string Department, string MainSubject, decimal BaseSalary,int ExperienceYears) : base(FirstName, LastName, Age, Email, Id)
        {
            this.Department = Department;
            this.MainSubject = MainSubject;
            this.BaseSalary = BaseSalary;
            this.ExperienceYears = ExperienceYears;
        }

        public void ShowTeacherInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"Departament: {Department} \nMainSubject: {MainSubject} \nBaseSalary {BaseSalary} \nExperienceYears: {ExperienceYears}");
        }

        public void CalculateSalary()
        {
            Console.WriteLine($"Maas: {BaseSalary+(ExperienceYears*50)}");
        }
    }
}
