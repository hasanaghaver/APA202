using _04_AccessModifiresEncupsulationNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class NonDrived
    {
        public NonDrived()
        {
            //name public oldugundan non drived diferrent clasdada gorunur
            Person person = new Person();
            Console.WriteLine(person.name);
            //privatet name 1 miras almamis ferqli asemblyde islemir
            //Console.WriteLine(person.name1); xeta verir
            //internal name2 burada islemir cunku ferqli asemblydedir
            //name3 private oldugundan ancaq oz clasinda gorunur
            //name4 protected internal non drived diferent asemblyde gorunmur
            //name5 private protected oldugundan drived different asemblyde elcatan deyil

        }
    }
}
