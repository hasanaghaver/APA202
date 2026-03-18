using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    public abstract class Vehicle
    {
        public string Brand {  get; set; }
        public string Model { get; set; }
        public int Year {get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel  {  get; set; }
        public int MaxSpeed {  get; set; }

        protected Vehicle(string brand,string model,int year,string plateNumber,int maxSpeed)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.PlateNumber = plateNumber;
            this.MaxSpeed = maxSpeed;
            this.FuelLevel = 100;
        }

        public string GetVehicleInfo()
        {
            return $"{Brand} {Model} {Year} {PlateNumber} {FuelLevel} {MaxSpeed}";
        }
        public void ShowBasicInfo()
        {
            Console.WriteLine($"Brand: {Brand} \nModel: {Model} \nYear: {Year} \nPlate number: {PlateNumber} \nFuel level: {FuelLevel} \nMax speed: {MaxSpeed}");
        }

        public abstract double CalculateFuelCost(double distance);
    }
}
