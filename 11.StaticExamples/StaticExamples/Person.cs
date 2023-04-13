using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExamples
{
    internal class Person
    {
        public static string WifiPassword = "Salam123";
        public static int Count { get; set; }

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }

        static Person()
        {
            Count = 20;
            WifiPassword = "Salam123" ;
        }
        public Person( string name, string surname)
        {

            Console.WriteLine("Adi ctor ishe dushdu");
            Name = name;
            Surname = surname;

            Count++;
            Id = Count;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Id} {Name} {Surname}");
        }
    }
}
