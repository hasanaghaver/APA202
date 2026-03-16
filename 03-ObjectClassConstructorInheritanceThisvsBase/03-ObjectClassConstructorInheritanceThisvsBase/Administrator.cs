using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    internal class Administrator: Person
    {
        public string Position;
        public string Department;
        public int AccessLevel;

        public Administrator(string FirstName, string LastName, int Age, string Email, string Id, string Position, string Department, int AccessLevel )
            : base(FirstName, LastName, Age, Email, Id)
        {
            this.Position = Position;
            this.Department = Department;
            this.AccessLevel = AccessLevel;
        }
        
        public void ShowAdminInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"Position: {Position} \nDepartment: {Department} \nAccessLevel: {AccessLevel}");
        }

        public void GrantAccess(Student student)
        {
            Console.WriteLine($"{this.FirstName} {student.FirstName} -adli telebeye giris icazesi verdi");
        }
    }
}
