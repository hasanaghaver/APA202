using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Truck : Vehicle
    {
        public double CargoCapacity;
        public int AxleCount;
        public double CurrentLoad;

        public Truck(string brand, string model, int year, string plateNumber, int maxSpeed,
                double cargoCapacity, int axleCount, double currentLoad)
                : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.CargoCapacity = cargoCapacity;
            this.AxleCount = axleCount;
            this.CurrentLoad = currentLoad;
        }

        public void ShowTruckInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"Cargo capacity: {CargoCapacity} \nAxle count: {AxleCount} \nCurrent load: {CurrentLoad} ");
        }
        public void LoadCargo(double weight)
        {
            if (CurrentLoad + weight <= CargoCapacity)
            {
                CurrentLoad += weight;
                Console.WriteLine("Yuk yuklendi");
            }
            else
            {
                Console.WriteLine("Truck bu qeder yuku dasiya bilmez!");
            }
        }

        public override double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        }
    }
}
