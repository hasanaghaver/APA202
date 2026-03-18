using _04_AccessModifiresEncupsulationNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    internal class Work : Person
    {
        public Work()
        {
            //name public oldugundan drived class different asemblyde gorunur
            Person person = new Person();
            Console.WriteLine(person.name);
            //protected name 1 drived amma ferqi asemblyde gorunur
            Console.WriteLine(this.name1);
            //internal name2 burada islemir cunku ferqli asemblydedir
            //name 3 private oldugundan ancaq oz clasinda gorunur
            //name4 protected internal oldugundan drived different asemblyde elcatandir
            Console.WriteLine(this.name4);
            //name5 private protected oldugundan non drived different asembly-de elcatan deyil
        }
    }
}


