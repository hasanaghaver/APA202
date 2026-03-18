using _05_AbstractClassPolymorphismForEach.Models;

namespace _05_AbstractClassPolymorphismForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int vehicleCount = 0;
            double totalSpeed = 0;
            double expensiveFuel= 0;
            Vehicle expensive = null;
            
            Car car1 = new("Mercedes","E200",2023,"10TT006",220,4,500,true);
            Car car2 = new("BMW","320i",2022,"90KK203",235,4,480,true);
            Car car3 = new("Tayota", "Camry", 2021, "10KN324", 210, 4, 524, true);

            Motorcycle moto1 = new("Yamaha", "R1", 2023, "10B021", 299, 998, false, "Sport");
            Motorcycle moto2 = new("Harley", "Davidson", 2022, "99d099", 180, 1868, true, "Cruiser");

            Truck truck1 = new("Man", "TGX", 2020, "90T0357", 120, 18.0, 3, 12.0);
            Truck truck2 = new Truck("Volvo", "FH16", 2021, "90-SU-291", 110, 25.0, 4, 18.0);

            Car[] cars = {car1, car2, car3};
            foreach (var item in cars)
            {
                item.ShowCarInfo();
                Console.WriteLine(item.CalculateFuelCost(500.0));
                Console.WriteLine("-------------------------------------");
            }
            Motorcycle[] motors= {moto1,moto2};
            foreach(var item in motors)
            {
                item.ShowMotorcycleInfo();
                Console.WriteLine(item.CalculateFuelCost(300.0));
                Console.WriteLine("-------------------------------------");
            }
            Truck[] trucks= {truck1,truck2};
            foreach (var item in trucks)
            {
                item.ShowTruckInfo();
                Console.WriteLine(item.CalculateFuelCost(800.0));
                Console.WriteLine("-------------------------------------");
            }

            truck1.LoadCargo(5.0);
            Console.WriteLine(truck1.CalculateFuelCost(800.0));

            Vehicle[] vehicles= {car1,car2, car3,moto1,moto2,truck1,truck2};
            foreach( var item in vehicles)
            {
                vehicleCount++;
                totalSpeed += item.MaxSpeed;

                double fuelCost = item.CalculateFuelCost(100.0);
                if (fuelCost>expensiveFuel)
                {
                    expensiveFuel = fuelCost;
                    expensive = item;
                }
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("Umumi statistika");
            Console.WriteLine($"Ümumi neqliyyat sayı: {vehicleCount}");
            Console.WriteLine($"Orta maksimum surət: {totalSpeed/vehicleCount}");
            Console.WriteLine($"En bahalı yanacaq xerci olan neqliyyat: {expensive.Brand} \n 100 km-e yanacaq serfiyati: {expensiveFuel}  ");


        }
    }
}
