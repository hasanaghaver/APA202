namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Person
    {
        public string name;
        protected string name1;
        internal string name2;
        private string name3;
        protected internal string name4;
        private protected string name5;
        private string name6="Test";

        //public Person(string name)
        //{
        //    this.name = name;
        //}
        public void GetInfo()
        {
            //public name oz classinda gorunur
            Console.WriteLine($"{name}");
            //protected namede oz clasinda gorunur
            Console.WriteLine(this.name1);
            //internal ancaq oz asemblysinde isleyir
            Console.WriteLine(this.name2);
            //name 3 private oldugundan ancaq oz clasinda gorunur
            Console.WriteLine(this.name3);
            //name 4  protected internal oldugundan oz clasinda isleyir
            Console.WriteLine(this.name4);
            //name5 private protected oldugundan oz clasinda gorunur
            Console.WriteLine(this.name5);

        }
    }
}
