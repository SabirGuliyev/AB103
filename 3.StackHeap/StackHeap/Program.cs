namespace StackHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ctrl+k+s  region almaq
            //ctrl+k+c  commente atmaq
            #region Value Reference Example
            //int a = 10;
            //int b = 10;


            //Console.WriteLine(a==b);


            //int[] numbers = { 1, 2, 3 };
            //int[] numbers2 ={ 1, 2, 3 };

            //Console.WriteLine(numbers==numbers2);

            //if (true)
            //{
            //    int[] arr = { 10, 20, 30 };
            //        Console.WriteLine( 10);
            //}



            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //} 
            #endregion
            #region Value Reference Mehtod Behavior
            //int a = 10;
            //ChangeValue(a);
            //Console.WriteLine(a);


            //int[] numbers = { 5, 10, 15 };

            //ChangeFirstElement(numbers);

            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //} 
            #endregion
            #region Array
            //int[] numbers = { 1, 2, 3, 5 };

            //int[] numbers2 = new int[0];

            //int[] numbers3= new int[5] {1,2,3,4,5};

            //for (int i = 0; i < numbers2.Length; i++)
            //{
            //    numbers2[i] =5;
            //}
            //foreach (int num in numbers2)
            //{
            //    Console.WriteLine(num);
            //} 
            #endregion
            #region Ref and Out
            //ref ve out
            //int a = 5;
            //int b = 10;
            //ChangeMultipleValue(ref a,ref b);

            //Console.WriteLine(a + " " + b);

            //int[] numbers = {1,2, 3};

            //ArrayAddValue(ref numbers, 4);
            //ArrayAddValue(ref numbers, 10);
            //ArrayAddValue(ref numbers, 20);

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //int[] numbers = { 1, 2, 3 };

            //Array.Resize(ref numbers, numbers.Length+1);
            //numbers[numbers.Length - 1] = 8;

            //for (int i = 0; i < numbers.Length; i++)
            //   {
            //        Console.WriteLine(numbers[i]);
            //   }

            //int choice=int.Parse(Console.ReadLine());

            //Console.WriteLine(choice);
            //string str=Console.ReadLine();
            //int num;
            //bool result=int.TryParse(str, out num);

            //Console.WriteLine(result+" "+num);

            //    int a =5;
            //ChangeValueRef(ref a);
            //Console.WriteLine(a); 
            #endregion

        }
        #region Ref and Out methods
        public static void ChangeValueRef(ref int num)
        {

            num += 5;

        }

        public static void ChangeValueOut(out int num)
        {
            num = 10;
            num += 5;

        }

        public static void ArrayAddValue(ref int[] arr, int num)
        {
            int[] newArr = new int[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            newArr[newArr.Length - 1] = num;

            arr = newArr;

        }

        public static void ChangeMultipleValue(ref int num, ref int num2)
        {
            num += 5;
            num2 += 10;


        }  
        #endregion
        #region Value Reference Mehtod Behavior
        //public static void ChangeFirstElement(int[] arr)
        //{
        //    arr[0] = 99;
        //}


        //public static void ChangeValue(int num)
        //{
        //    num += 5;

        //} 
        #endregion
    }
}