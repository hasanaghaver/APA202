namespace _04_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new("Mercedes", "E280", 1996);
            vehicle.StartEngine();
            vehicle.Drive(300);
            vehicle.StopEngine();
            vehicle.VehicleInfo();

            Console.WriteLine("----------------------------------------------");

            Car car = new("BMW","F30",2013,50.0,20.0,13);
            car.Refuel(20);
            car.VehicleInfo();
        }
    }
}
