using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    internal class Student:Person
    {
        public bool IsStudent;

        public Student()
        {
            //name public olduguna gore drived gorunur
            Console.WriteLine(this.name);
            //protected name 1 drived olunmus clasdada gorunur
            Console.WriteLine(this.name1);
            //internal ancaq oz asemblysinde isleyir
            Console.WriteLine(this.name2);
            //name 3 private oldugundan ancaq oz clasinda gorunur
            //name 4 protected internal oldugunlan drived clasdada elcatandir
            Console.WriteLine(this.name4);
            //name5 private protected oldugunda drived clasda gorunur
            Console.WriteLine(this.name5);
        }
    }
   
}
