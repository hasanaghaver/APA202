namespace _01_C_IntroMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.Hər biri 2 parametr qəbul edib və riyazi əməlləri yerinə yetiren method yazin

            //Console.WriteLine("Birinci ededi daxil edin:");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Ikinci ededi daxil edin:");
            //int b = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Emelliyati daxil edin: \nYalnizca * / + - kecerlidir");
            //string c = "";
            //while (true)
            //{
            //    c = Console.ReadLine();
            //    if (c == "+" || c == "-" || c == "*" || c == "/")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Daxil etdiyiniz simvol standarta uygun deyil!");
            //    }
            //}
            //Console.WriteLine($"Emeliyyatin neticesi: {Emeliyyat(a, b, c)}");


            //2.Verilen arqumentlere uygun tek ve cut edeleri tapan method yazin.(14, 20, 35, 40, 57, 60, 100)
            //OddAndEven(14, 20, 35, 40, 57, 60, 100);

            //3.Verilmis arreyde elementlerin həm 4-ə, həm də 5-ə bölününen elementlerin cemini tapin.[14, 20, 35, 40, 57, 60, 100]
            //Console.WriteLine($"Verilmis Arrayda 4-e ve 5-e bolunen ededlerin cemi: {DordVeBeseBolunme(14, 20, 35, 40, 57, 60, 100)}");

            //4 .Daxil edilmiş cümlədə daxil edilmis simvoldan nece eded olduğunu tapan Proqramın alqoritmini yazin.(Cumle serbestdir).
            //Console.WriteLine("Bir metn daxil edin:");
            //string metn = Console.ReadLine();
            //Console.WriteLine("Hansi herfin sayini tapilmalidir?");
            //char herf = Convert.ToChar(Console.ReadLine());
            //Console.WriteLine($"Daxil olunan metnde {herf}-simvolundan {Counter(metn, herf)} eded var");
        }
        // Task 1 in methodu
        public static double Emeliyyat(int a, int b, string c)
        {
            switch (c)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return (double)a / b;
            }
            return -1;
        }

        // Task2 -nin methodu
        public static void OddAndEven(params int[] nums)
        {
            string odd = "";
            string even = "";
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    even += nums[i] + " ";
                }
                else
                {
                    odd += nums[i] + " ";
                }
            }
            Console.WriteLine($"Arrey-deki cut ededler: {even}");
            Console.WriteLine($"Arrey-deki tek ededler: {odd}");

        }

        //Task 3-un methodu
        public static int DordVeBeseBolunme(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 4 == 0 && arr[i] % 5 == 0)
                {
                    sum += arr[i];
                }
            }
            return sum;
        }


        //Task 4-un methodu
        public static int Counter(string a, char b)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (char.ToLower(a[i]) == b)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
