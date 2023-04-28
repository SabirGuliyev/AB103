namespace ThreadTask
{
    internal class Program
    {

        public static int Count = 0;
        public static object blockObj=new object();
        public static object blockObj2=new object();
        static void Main(string[] args)
        {


            #region Thread
            //Thread thread = new Thread(LoopIncrement);
            //Thread thread2 = new Thread(LoopDecrement);


            //thread.Start();
            //thread2.Start();



            //thread.Join();
            //thread2.Join();

            //Console.WriteLine(Count); 
            #endregion

            //Task task = Task.Run(() =>
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //    Console.WriteLine(i);
            //    }
            //});
            //Task task2 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        Console.WriteLine("2ci-----"+i);
            //    }
            //});

            //task.Wait();
            //task2.Wait();

            //Console.WriteLine("Bitdi");
            //Console.ReadLine();

            var task=Task.WhenAll(Loop(), Loop2());

            task.Wait();
            Console.WriteLine(task.IsCompletedSuccessfully);
          
        }

        public static async Task Loop()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine(i);
                }
            });
        }
        public static async Task Loop2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("2ci-----" + i);
                }
            });
        }
        #region Thread examples
        public static void LoopIncrement()
        {

            for (int i = 0; i < 1000; i++)
            {
                //lock (blockObj2)
                //{

                //    lock (blockObj2)
                //    {
                //        Count++;
                //    }
                //}
                Console.WriteLine("1 ci dovr ishleyir");

            }
        }

        public static void LoopDecrement()
        {

            for (int i = 0; i < 1000; i++)
            {

                //lock (blockObj)
                //{

                //    lock (blockObj)
                //    {
                //        Count--;
                //    }
                //}
                Console.WriteLine("2 ci dovr");

            }
        }
        #endregion
    }
}