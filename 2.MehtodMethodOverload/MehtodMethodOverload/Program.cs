namespace MehtodMethodOverload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Method examples

            //Console.WriteLine("Salam");
            //int price = 90;
            //int result = price * 20 / 100;
            //Console.WriteLine(result);

            //int price2 = 60;
            //int result2 = price2 * 30 / 100;
            //Console.WriteLine(result2);

            //GetDiscount(90,20);
            //GetDiscount(100, 30);

            //string fullname = GetFullname("Sabir", "Guliyev");
            //Console.WriteLine(fullname);

            //GetSum(4, 10);
            //int[] numbers = {1,2,3,4};


            //int result=GetArraySum(numbers);
            //Console.WriteLine(result);

            //string fullname = GetFullname(surname:"Guliyev");
            //Console.WriteLine(fullname);
            //int[] numbers = {1,2,3,4};
            //int result=GetArraySum(numbers);


            //Console.WriteLine(GetFullname("Sabir"));
            // int result2 = GetNumbersSum(5,6,7,8,9,10);
            // Console.WriteLine(result2);



            //bool result= CheckOddOrEven(6);
            // Console.WriteLine(result);

            //int[] numbers = {1,2,3,4,5};

            //Console.WriteLine(GetSum2(numbers));

            //int[] numbers2 = { 5, 6, 7, 8, 9, 10 };
            //Console.WriteLine(GetSum2(numbers2));

            //Console.WriteLine(GetSum2(1,4,5,10));
            #endregion

            //Sum(10d, 2);
            //Sum(10m, 2);
            //Sum(1,3,5d);

            //Sum(1,2,3,4,5,6);

        }

        #region Priority

        public static void Sum(int num, int num2)
        {
            Console.WriteLine("2 pramli method");

            Console.WriteLine(num + num2);
        }
        public static void Sum(int num, int num2, int num3 = 0)
        {
            Console.WriteLine("3 pramli method");
            Console.WriteLine(num + num2 + num3);
        }
        public static void Sum(int num, int num2, params int[] numbers)
        {
            Console.WriteLine(" params method");
            Console.WriteLine(num + num2);
        } 
        #endregion

        #region Overload
        //public static void Sum(int num,double num2)
        //{
        //    Console.WriteLine("double 1ci de olan method");
        //    Console.WriteLine(num+num2);
        //}
        //public static int Sum(double num2, int num)
        //{
        //    Console.WriteLine("double 2cide olan method");
        //    Console.WriteLine(num2 + num);
        //    return num;
        //}
        //public static void Sum(decimal num, int num2)
        //{
        //    Console.WriteLine("decimal method");
        //    Console.WriteLine(num + num2);
        //}
        //public static void Sum(int num, int num2,int num3)
        //{
        //    Console.WriteLine("2ci method");
        //    Console.WriteLine(num + num2+num3);
        //}
        //public static void Sum(int num, int num2, int num3,int num4)
        //{
        //    Console.WriteLine("3ci method");
        //    Console.WriteLine(num + num2 + num3+num4);
        //}

        #endregion

        #region Mehtods
        //public static int GetSum2( params int[] arr)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        sum += arr[i];
        //    }

        //    return sum;
        //}
        //public static bool CheckOddOrEven(int num)
        //{
        //    bool result=false;

        //    if (num%2==0)
        //    {
        //        result = true;
        //    }

        //    return result;
        //}
        //public static void GetDiscount(int price, int percent)
        //{
        //    int result = price * percent / 100;




        //    if (result>5)
        //    {

        //        Console.WriteLine("Endirim 5den boyukdur");

        //    }
        //    Console.WriteLine(result);
        //}

        //public static string GetFullname(string name,string surname = "XXX")
        //{
        //    string fullname = name + " " + surname;

        //    return fullname;
        //}
        //public static int GetArraySum(int[] arr)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        sum += arr[i];
        //    }
        //    if (sum<5)
        //    {
        //        sum = 0;
        //    }
        //    return sum;
        //}
        //public static int GetNumbersSum(params int[] arr)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        sum += arr[i];
        //    }

        //    return sum;
        //} 
        #endregion

    }
}