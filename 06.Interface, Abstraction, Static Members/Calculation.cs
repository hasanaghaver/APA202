using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Interface__Abstraction__Static_Members
{
    internal class Calculation : ICalculation
    {
        public double Calculate(double a, double b, char operation)
        {
            switch (operation)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Sifira bolme emeliyyati yoxdur.");
                        return 0;
                    }
                    return a / b;
                default:
                    Console.WriteLine("Emeliyyat duzgun daxil edilmeyib!");
                    return 0;
            }
        }
    }
}
