using _04_AccessModifiresEncupsulationNamespace.Models;
using System;
using System.Reflection;

namespace _04_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person();
            //Student student = new Student();
            //Console.WriteLine(student.name);

            ////private name3 encupsulation
            
            ////typeof(Person).GetField("name3", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(person, "APA202");
            ////var newName =typeof(Person).GetField("name3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(person);

            ////Console.WriteLine(newName);

            ////private name6 nin deyerini cap etmek istesek
            //var newName = typeof(Person).GetField("name6", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(person);
            //Console.WriteLine(newName);

            Car car = new Car();
            //car.HoursePower = 50;
            Console.WriteLine(car.HoursePower);

        }
    }
}
