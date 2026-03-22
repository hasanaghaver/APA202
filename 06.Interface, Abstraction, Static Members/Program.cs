namespace _06.Interface__Abstraction__Static_Members
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Birinci ededi daxil edin:");
            double n1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Emeliyyati daxil edin: \nYalnizca *,/,+,-");
            char op = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Ikinci ededi daxil edin:");
            double n2 = Convert.ToDouble(Console.ReadLine());

            Calculation calculation1 = new Calculation();

            double result = calculation1.Calculate(n1, n2, op);
            Console.WriteLine($"Netice: {result}");
        }
    }
}
