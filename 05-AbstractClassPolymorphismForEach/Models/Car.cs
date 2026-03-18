using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Car : Vehicle
    {
        public int DoorsCount;
        public int TrunkCapacity;
        public bool IsAutomatic;


        public Car(string brand, string model, int year, string plateNumber,
            int maxSpeed, int doorsCount, int trunkCapacity, bool isAutomatic)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.DoorsCount = doorsCount;
            this.TrunkCapacity = trunkCapacity;
            this.IsAutomatic = isAutomatic;
        }
        public void ShowCarInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"Doors count: {DoorsCount} \nTrunk capacity: {TrunkCapacity} \nIsAutomatic: {IsAutomatic}");
        }

        public override double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.50;
        }
    }
}
