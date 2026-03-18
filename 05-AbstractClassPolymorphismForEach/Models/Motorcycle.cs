using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Motorcycle: Vehicle
    {
        public int EngineCapacity;
        public bool HasSidecar;
        public string Type;

        public Motorcycle(string brand, string model, int year, string plateNumber,
            int maxSpeed, int engineCapacity, bool hasSidecar, string type)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.EngineCapacity = engineCapacity;
            this.HasSidecar = hasSidecar;
            this.Type = type;
        }
        public void ShowMotorcycleInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"Engine capacity: {EngineCapacity} \nHas Sidecar: {HasSidecar} \nType: {Type}");
        }
        public override double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 4 * 1.50;
        }
    }
}
