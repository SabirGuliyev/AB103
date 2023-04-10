using AccessEncapsulationRecord.Models;
using System;
using System.Text.RegularExpressions;

namespace AccessEncapsulationRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Encapsulation
            //PersonClass personClass = new PersonClass("sabir",20);


            //Console.WriteLine("Adinizi daxil edin:");
            //personClass.Name = Console.ReadLine();

            //personClass.SetName("    ali    ");

            //Console.WriteLine(personClass.GetName());


            //personClass.GetInfo();




            //PersonClass personClass = new PersonClass("Ar",250);
            //personClass.Name = "Sa";
            //personClass.Age = 210;
            //Console.WriteLine(personClass.Name+" "+personClass.Age); 
            #endregion


            #region Record
            //PersonClass personClass = new PersonClass("Sabir",25);
            //PersonClass personClass2 = new PersonClass("Sabir", 25);
            //personClass.Age = 45;
            //Console.WriteLine(personClass==personClass2);
            //Console.WriteLine(personClass);


            //PersonRecord person = new PersonRecord("Sabir",25);
            //PersonRecord person2 = new PersonRecord("Sabir", 25);
            //person = person with
            //{
            //    Age=45
            //};


            //StudentRecord student = new StudentRecord("Arif", 20);
            //Console.WriteLine(person == person2);
            //Console.WriteLine(person); 
            #endregion

            #region Tuple
            //Tuple

            //(string Name, int Days) month = ("Yanvar", 31);

            ////month.Item1 = "Fevral";
            ////month.Item2 = 28;

            ////month.Name = "Mart";
            ////month.Days = 31;

            //var month2 = Tuple.Create("Month", true, 15, 30f);
            //var month4 = Tuple.Create("Month", true, 15, 30f);
            //Console.WriteLine(month2==month4);

            //var month3 = ValueTuple.Create("Month", true, 15, 30f);

            ////Console.WriteLine(month2);
            //int[] numbers = { 7, 3, 5, 1, 23, 45 };




            //var result=ArrMinMax(numbers);
            //var result2 = result;
            //result2.Max = 300;

            //Console.WriteLine(result);
            //Console.WriteLine(result==result2);


            #endregion



            int num = 4;
            string word = @$"{num }sfdsf";
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


            Console.WriteLine(regex.IsMatch("sabir.guliyev@code.edu.az."));


        }

        public static (int Min,int Max) ArrMinMax(int[] arr)
        {

            return (arr.Min(), arr.Max());
        }
    }
}