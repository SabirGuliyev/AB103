using GenericTypeCollections.Models;
using GenericTypeCollections.Models.Animals;
using GenericTypeCollections.Models.Foods;
using System.Collections;

namespace GenericTypeCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Generic Type

            //Product<int> productNum = new Product<int>(100);

            //Product<char> productSymbol = new Product<char>('A');

            //Product<string> product = new Product<string>("High");

            //Console.WriteLine(product.Quality);
            //Console.WriteLine(productNum.Quality);
            //Console.WriteLine(productSymbol.Quality);




            //Lion lion = new Lion { AvgLifetime = 3,Name="Simba",Paws=4 };
            //Elephant elephant = new Elephant { AvgLifetime = 30, Name = "Pumba",Weight=345.5};


            //ZooCage<Lion,Meat> zoo = new ZooCage<Lion,Meat>(lion);

            //ZooCage<Elephant,Grass> zoo2 = new ZooCage<Elephant,Grass>(elephant); 
            #endregion

            Lion lion = new Lion();

            ArrayList arrayList = new ArrayList() {lion,5,4.5m,'a',"Salam"};

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);

            //}


            //SortedList sortedList = new SortedList();
            //sortedList.Add(1, "Baku");
            //sortedList.Add("", "Berde");


            //SortedList<int, string> collection = new SortedList<int, string>();


            //collection.Add(5, "Baku");
            //collection.Add(2, "Berde");
            //collection.Add(2, "Berde");
            //collection.Add(3, "Sumqayit");


            //foreach (var item in collection)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}



            //LIFO
            //Stack<string> names = new Stack<string>();

            //names.Push("Arif");
            ////names.Push("Nahid");
            ////names.Push("Nermin");


            ////names.Pop();
            ////names.Pop();


            ////string result;
            ////names.TryPop(out result);

            ////Console.WriteLine(result);


            //Console.WriteLine(names.Peek());
            //Console.WriteLine(names.Peek());
            //Console.WriteLine(names.Peek());
            //Console.WriteLine(names.Peek());

            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}



            //FIFO
            //Queue<string> names=new Queue<string>();

            //names.Enqueue("Arif");
            //names.Enqueue("Nahid");
            //names.Enqueue("Narmin");

            //names.Peek();

            //names.TryDequeue();
            //names.Dequeue();
            //names.Dequeue();
            //names.Dequeue();

            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}



            //Dictionary<string, string> countries = new Dictionary<string, string>();

            //countries.Add("Aze", "Tbilisi,Batumi");

            //countries.TryAdd("Geo", "Baku,Berde");

            //countries.Remove("Geo");

            //foreach (var item in countries)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}






            List<int> nums = new List<int>() { 1,2,3,4,5,3};

            //nums.Add(4);

            //nums.RemoveAll(x=>x>3);

            for (int i = 0; i < nums.Count; i++)
            {
                Console.WriteLine(nums[i]);
            }
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }





        }
    }
}