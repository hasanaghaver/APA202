using _07_NullableEnumStruct.Enums;

namespace _07_NullableEnumStruct
{
    internal class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size {  get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }

        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
            Status = OrderStatus.New;
            Price = CalculatePrice();
        }

        public decimal CalculatePrice()
        {
            switch (Drink)
            {
                case DrinkType.Coffee:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            return 3;
                        case DrinkSize.Medium:
                            return 4;
                        case DrinkSize.Large:
                            return 5;
                    }
                    break;
                case DrinkType.Juice:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            return 4;
                        case DrinkSize.Medium:
                            return 5;
                        case DrinkSize.Large:
                            return 6;
                    }
                    break;
                case DrinkType.Water:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            return 1;
                        case DrinkSize.Medium:
                            return 1.5M;
                        case DrinkSize.Large:
                            return 2;
                    }
                    break;
                case DrinkType.Tea:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            return 2;
                        case DrinkSize.Medium:
                            return 3;
                        case DrinkSize.Large:
                            return 4;
                    }
                    break;
                default:
                    Console.WriteLine("Deyerler dogru daxil edilmeyib");
                    break;

            }
            return 0;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifariş #{OrderNumber} statusu: {Status}");
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order Number: {OrderNumber} \nCustomerName: {CustomerName} \nDrink:{Drink}" +
                $"\nSize: {Size} \nStatus: {Status} \nPrice:{Price}");
        }
    }
}
