using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionException.Models
{
    internal class Dog:Animal
    {
        public byte Paws { get; set; }
        public string Name { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Hav hav");
        }
    }
}
