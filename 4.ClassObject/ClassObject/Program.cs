

using ClassObject.Models;

namespace ClassObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Fuuu
            //string name = "Ismayil";
            //string surname = "Israfilli";
            //byte age = 22;

            ////Console.WriteLine("{0} {1} {2}",name,surname,age);
            //Console.WriteLine($"Name:{name} Surname:{surname} Age:{age}");

            //string name2 = "Sakina";
            //string surname2 = "Allahverdiyeva";
            //byte age2 = 23;
            //Console.WriteLine($"Name:{name} Surname:{surname2} Age:{age2}"); 
            #endregion

            #region Anonimous Object
            //object person = new
            //{
            //    Name = "Ismayil",
            //    Surname = "Israfilli",
            //    Age = 22
            //};


            //Console.WriteLine(person.GetType().GetProperty("Name").GetValue(person));
            //object person2 = new
            //{
            //    Name = "Saleh",
            //    Surname = "Nebiyev",

            //};
            //object person3 = new
            //{

            //    Surname = "Abdulla",
            //    Age = 20
            //}; 
            #endregion


            //Person person=new Person();
            //person.Name = "Ismayil";
            //person.Surname = "Israfilli";
            //person.Age = 22;

            //person.GetInfo();

            //Person person2 = new Person
            //{
            //    Name="Arif",
            //    Surname="Abdulla",
            //    Age=22
            //};

            //person2.GetInfo();











            //Person person = new Person();
            //Person person2 = new Person("Sabir");
            //Person person3 =new Person("Sabir","Guliyev");
            //Person person4 =new Person("Sabir","Guliyev",25);
            //Person person = new Person("Sabir", "Guliyev");
            //person.GetInfo();








            //Student student = new Student();
            //Teacher teacher = new Teacher();






        }

    }
    class Person
    {
        //field
        public string Name;
        public string Surname;//Default deyer gonderilmese XXX olacaq
        public byte Age;


        public Person(string name)
        {
            Console.WriteLine("Person ctoru ishe dushdu");
        }

        








        #region This Ctor
        //public Person()
        //{
        //    Console.WriteLine("Person created");
        //}
        //public Person(string name):this()
        //{
        //    Name = name;
        //}
        //public Person(string name,string surname):this(name)
        //{
        //    Surname = surname;
        //}
        //public Person(string name,string surname,byte age):this(name,surname)
        //{
        //    Age = age;
        //} 
        #endregion

        #region Ctor Overload
        //public Person()
        //{
        //    Console.WriteLine("Person created");

        //}
        //public Person(string name)
        //{
        //    Name = name;
        //}
        //public Person(string name,string surname)
        //{
        //    Name=name;
        //    Surname = surname;
        //}

        //public Person(string name, string surname, byte age)
        //{
        //    Name = name;
        //    Surname = surname;
        //    Age = age;
        //} 
        #endregion

        //Method
        public void GetInfo()
        {
            Console.WriteLine($"Name:{Name} Surname:{Surname} Age:{Age}");
        }
    }
}