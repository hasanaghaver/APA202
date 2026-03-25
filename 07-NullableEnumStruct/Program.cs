using _07_NullableEnumStruct.Enums;

namespace _07_NullableEnumStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sifaris 1
            DrinkOrder order1 = new DrinkOrder(101,"Ali",DrinkType.Coffee,DrinkSize.Medium);
            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Preparing);
            order1.UpdateStatus(OrderStatus.Ready);
            order1.UpdateStatus(OrderStatus.Delivered);
            Console.WriteLine("-----------------------------------------------------------");

            //Sifaris 2
            DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            order2.DisplayOrder();
            order2.UpdateStatus(OrderStatus.Ready);
            Console.WriteLine("-----------------------------------------------------------");

            //Sifaris 3
            DrinkOrder order3 = new DrinkOrder(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
            order3.DisplayOrder();
            Console.WriteLine("-----------------------------------------------------------");

            foreach (DrinkType item in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine((int)item + " "+ item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            foreach (DrinkSize item in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine((int)item + " "+ item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            foreach (OrderStatus item in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine((int)item + " "+ item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //toSting methodlari
            string drinkToString = DrinkType.Coffee.ToString();
            Console.WriteLine($"DrinkType.Coffee.ToString() dan alinan netice: {drinkToString}");
            Console.WriteLine("-----------------------------------------------------------");

            string drinkToSize = DrinkSize.Large.ToString();
            Console.WriteLine($"DrinkSize.Large.ToString() dan alinan netice: {drinkToSize}");
            Console.WriteLine("-----------------------------------------------------------");

            //Parse() methodu
            string drink = "Tea";
            DrinkType parseType = (DrinkType)Enum.Parse(typeof(DrinkType),drink);

            string size = "Medium";
            DrinkSize parseSize = (DrinkSize)Enum.Parse (typeof(DrinkSize),size);

            int count = 0;

            Object[] orders = {order1,order2,order3 };
            foreach (var item in orders)
            {
                count++;
            }

            Console.WriteLine($"Sifaris sayi {count}");
            Console.WriteLine(order1.Price);
            Console.WriteLine(order2.Price);
            Console.WriteLine(order3.Price);
            decimal totalPrice = order1.Price + order2.Price +order3.Price;
            Console.WriteLine($"Umumi mebleg: {totalPrice}");
        }

    }
}
