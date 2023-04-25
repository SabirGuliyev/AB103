using StructEnumIndexer.Indexer;
using StructEnumIndexer.Models;
using StructEnumIndexer.Utilities.Enums;

namespace StructEnumIndexer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Struct
            //struct

            //PointClass pointClass;
            //PointClass pointClass2 = new PointClass(1, 2);

            //Console.WriteLine(pointClass==pointClass2);
            ////pointClass.GetCordinates();

            //PointStruct point ;


            //PointStruct point2 = new PointStruct(3, 4);

            //Console.WriteLine(point.X == point2.Y);
            //point.GetCordinates(); 
            #endregion

            #region Indexer
            //int[] arr = {1,2,3};


            //ListInt numbers = new ListInt(4);

            //ListInt numbers2 = new ListInt(1,2,3,4,5,6);

            //numbers2.Add(20);

            //numbers2[20] = 5;


            //for (int i = 0; i < numbers2.Length; i++)
            //{
            //    Console.WriteLine(numbers2[i]);
            //}


            //Console.WriteLine(numbers2[20]); 
            #endregion


            //Enum 
            Console.WriteLine("Zehmet olmasa reqem daxil edin:");

            foreach (CustomWeek day in typeof(CustomWeek).GetEnumValues())
            {
                Console.WriteLine((int)day+" "+day);
            }
            byte choice;
            string str=Console.ReadLine();
            byte.TryParse(str,out choice);


            switch (choice)
            {
                case (byte)CustomWeek.Monday:
                    Console.WriteLine(CustomWeek.Monday);
                    break;
                case (byte)CustomWeek.Tuesday:
                    Console.WriteLine(CustomWeek.Tuesday);
                    break;
                case (byte)CustomWeek.Wednesday:
                    Console.WriteLine(CustomWeek.Wednesday);
                    break;
                case (int)CustomWeek.Thursday:
                    Console.WriteLine(CustomWeek.Thursday);
                    break;
                case (int)CustomWeek.Friday:
                    Console.WriteLine(CustomWeek.Friday);
                    break;
                case (int)CustomWeek.Saturday:
                    Console.WriteLine(CustomWeek.Saturday);
                    break;
                case (int)CustomWeek.Sunday:
                    Console.WriteLine(CustomWeek.Sunday);
                    break;

                default:
                    Console.WriteLine("Yanlish deyer gonderilib");
                    break;



            }


            CusList<string> arr = new CusList<string>("Salam","Necedir");




            //switch (choice)
            //{
            //    case 1:
            //        Console.WriteLine("Monday");
            //        break;
            //    case 2:
            //        Console.WriteLine("Tuesday");
            //        break;
            //    case 3:
            //        Console.WriteLine("Wednesday");
            //        break;
            //    case 5:
            //        Console.WriteLine("Thursday");
            //        break;
            //    case 4:
            //        Console.WriteLine("Friday");
            //        break;
            //    case 6:
            //        Console.WriteLine("Saturday");
            //        break;
            //    case 7:
            //        Console.WriteLine("Sunday");
            //        break;

            //    default:
            //        Console.WriteLine("Yanlish deyer gonderilib");
            //        break;
            //}









        }
    }
}