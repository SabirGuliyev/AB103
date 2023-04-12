using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVirtualPolymorphism
{
    internal class Student:Person
    {
        public string Group { get; set; }


        public sealed override void GetInfo()
        {
            Console.WriteLine($"Name:{Name} Group:{Group}");
        }
    }
}
