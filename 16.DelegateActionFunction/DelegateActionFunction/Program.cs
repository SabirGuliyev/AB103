namespace DelegateActionFunction
{
    internal class Program
    {
        public delegate bool CheckNumber(int num);
        public delegate void Print<T>(T message);
        static void Main(string[] args)
        {


            //Print<string> print = x => Console.WriteLine(x);
            //print("Salam");



            //Print<int> print2=x => Console.WriteLine(x);
            //print2(5);

            //Print print = new Print(x => Console.WriteLine(x));
            int[] numbers = { 1, 2, 3, 4, 5 };

            //int result=Sum(numbers,IsOdd);
            //int result2 = Sum(numbers, IsEven);


            //Console.WriteLine(Sum(numbers,delegate(int num)
            //{
            //    return num%3==0;
            //}));


            //Console.WriteLine(Sum(numbers, x => x < 0));


            //Console.WriteLine(result2);
            //Console.WriteLine(SumOdd(numbers));



            //Print print = delegate (string word)
            //{
            //    Console.WriteLine(word[0]);
            //};


            //print += x => Console.WriteLine(x[x.Length-1]);

            ////print -= x => Console.WriteLine(x[x.Length - 1]); silmeyecek

            //print.Invoke("salam");






            List<int> list=new List<int> { 1, 2, 3, 4, 5 };

            list.Find(x => x > 3);
            list.ForEach(x=>Console.WriteLine(x));
            Action action = () => Console.WriteLine("Salam");

            //print += PrintUpper;
            //print += PrintCapitalize;

            //print -= PrintCapitalize;

            //print.Invoke("sAlAm");






            //Action<int, string> action = (x, n) =>
            //{
            //    Console.WriteLine(x);
            //    Console.WriteLine(n);
            //};

            //Func<string, char> func = delegate (string word)
            //{
            //    return word[0];
            //};
            //Func<int,bool>
            //Predicate<int>

            //Console.WriteLine(func("salam"));





            List<int> ints = new List<int>() { 1,2,3,4,5,6,7,8};

           
            Console.WriteLine(ints.Find(x => x > 0));



            Console.WriteLine(Sum(numbers, x => x >0));

            //PrintUpper(5);
            //PrintUpper('A');
            //PrintUpper("Azer");


        }

        public static void PrintEverything(Action<int,string> action)
        {
            action(5, "Salam");
        }



        //public static void PrintUpper<T>(T word)
        //{
        //    Console.WriteLine(word);
        //}
        //public static void PrintLower(string word)
        //{
        //    Console.WriteLine(word.ToLower());
        //}
        //public static void PrintCapitalize(string word)
        //{
        //    Console.WriteLine(Char.ToUpper(word[0]) + word.Substring(1).ToLower());
        //}
        public static int Sum(int[] arr, Predicate<int> predicate)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (predicate(arr[i]))
                {
                    sum += arr[i];
                }
            }

            return sum;
        }


        //public static bool Check(int num,Predicate<int> predicate)
        //{
        //    return predicate(num);
        //}
       
    }
}