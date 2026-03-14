namespace _02_HeapStackRefOutArrayResize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task Sinifde izah etdiyim kimi yazdigimiz CustomArrResize metoduna ikinci parameter olaraq nums arrayi gondereceksiniz.
            int[] a= { 1, 2, 3, 4};
            int[] nums= { 5, 6, 7, 8, 9 };

            CustomArrResize(ref a,nums);


            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

        }

        public static void CustomArrResize(ref int[] arr1, int[] nums)
        {
            int[] newArr = new int[arr1.Length + nums.Length];
            for (int i = 0; i < newArr.Length; i++)
            {
                if (i<arr1.Length)
                {
                    newArr[i] = arr1[i];
                }
                else
                {
                    newArr[i] = nums[i-arr1.Length];
                }
            }
            arr1 = newArr;

        }
    }
}
