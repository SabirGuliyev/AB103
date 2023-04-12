using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVirtualPolymorphism
{
    internal class Person
    {
        public string Name { get; set; }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Name:{Name}");
        }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
