using StaticExtension.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExtension.Models
{
    internal class Person
    {
        public static int Count { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string name, string surname)
        {
            Name = name.Capitalize();
            Surname = surname.Capitalize();
            

        }
        public void GetInfo()
        {
            Console.WriteLine(Name+" "+Surname+" "+Count);
        }
        
    }
}
