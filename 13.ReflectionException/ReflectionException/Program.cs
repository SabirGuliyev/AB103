using ReflectionException.Exceptions;
using ReflectionException.Models;
using System.Reflection;

namespace ReflectionException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Reflection
            //Assembly assembly=Assembly.GetExecutingAssembly();

            ////MethodInfo
            //Type[] types=assembly.GetTypes();

            //foreach (Type type in types)
            //{
            //    Console.WriteLine(type.Name+"---------------------");

            //    //foreach (MemberInfo member in type.GetMembers())
            //    //{
            //    //    Console.WriteLine(member);
            //    //}

            //    foreach (var item in type.GetFields())
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //Teacher teacher = new Teacher { Name="Sabir",Salary=77777};


            //var type=teacher.GetType();

            //FieldInfo field = type.GetField("_exp",BindingFlags.NonPublic|BindingFlags.Instance);

            //field.SetValue(teacher,(byte)4);


            //Console.WriteLine(field.GetValue(teacher)); 

            //Type type = typeof(Teacher);
            //Type type1=teacher.GetType(); 


            //foreach (var mem in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance ))
            //{
            //    Console.WriteLine(mem.Name);
            //}
            #endregion

            #region Exception
            //Student student = new Student(50, "sabir");


            //string[] names = { "Saleh", "Narmin", "Arif" };

            //var result = Search(names, "Nahid"); 
            //try
            //{
            //    string word = "salam";
            //    int num = int.Parse(Console.ReadLine());
            //    int num2 = int.Parse(Console.ReadLine());

            //    Console.WriteLine(num / num2);

            //    Console.WriteLine(word[20]);

            //}

            //catch (FormatException e)
            //{

            //    //Console.WriteLine(e.Message);
            //    int num = 5;
            //    int num2 = 1;
            //    Console.WriteLine("Format olan idare olundu");
            //    Console.WriteLine(num);
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("0-a bolmek olmur qadasi");
            //}
            //catch (Exception e)
            //{

            //    throw new Exception("Sorry error var");
            //}
            //finally
            //{
            //    Console.WriteLine("Finally ishledi");
            //}




            //Console.WriteLine("finally den coldeki kod ishledi");


            #endregion

            //Upcasting Downcasting

            


            Animal dog = new Dog { AvgLifetime = 4, Name = "bobik", Paws=4};
            Animal eagle=new Eagle { AvgLifetime=5,FlySpeed=120};
 



            object[] animals = { dog, eagle };


            //Dog dog1 =(Dog)dog;


            //Console.WriteLine(dog1.Paws+" "+dog1.Name);
            foreach (var animal in animals)
            {

                //Dog test = (Dog)animal;





                if (animal is Dog dog4)
                {

                    //Dog dog2 = (Dog)animal;
                    //Dog dog3 = animal as Dog;


                    Console.WriteLine(dog4.Name);
                }



            }


            //Console.WriteLine(animal.GetType().Name);
        }


        //public static string Search(string[] arr, string search)
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i] == search)
        //        {
        //            return search;
        //        }
        //    }

        //    throw new NotFoundException($"{search} was not found");

        //}
    }
}