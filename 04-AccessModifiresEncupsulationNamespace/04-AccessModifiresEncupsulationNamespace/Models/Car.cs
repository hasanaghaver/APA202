using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Car
    {
        private int _hoursePower = 200;

        public int HoursePower
        {
            get
            {
                return _hoursePower;
            }
            set
            {
                //_hoursePower = value;
            }
        }
        public Car()
        {
            //name public olduguna gore miras almayan classdada gorunur
            Person person = new Person();
            Console.WriteLine(person.name);
            //protected name1 artig eyni asemlyde olan non drivede gorunmur
            //Console.WriteLine(person.name1); xeta verir
            //name 2internal ancaq oz asemblysinde isleyir
            Console.WriteLine(person.name2);
            //name3 private oldugundan ancaq oz clasinda gorunur
            //name4 protected internal oldugundan non drived clasdada isleyir
            Console.WriteLine(person.name4);
            //name5 private protected oldugundan non drived clasda gorunmur
        }
    }
}
