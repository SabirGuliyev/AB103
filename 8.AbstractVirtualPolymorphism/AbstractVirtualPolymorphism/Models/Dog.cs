using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVirtualPolymorphism.Models
{
    internal class Dog:Animal
    {
        public string Breed;

        public override void MakeSound()
        {
            Console.WriteLine("Hav Hav");
        }

        public override void Eat()
        {
            Console.WriteLine("Et ilede qidalanir");
        }
    }
}
