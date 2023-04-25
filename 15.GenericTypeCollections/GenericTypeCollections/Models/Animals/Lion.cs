using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeCollections.Models.Animals
{
    internal class Lion:Animal
    {
        public byte Paws { get; set; }


        public void Roar()
        {
            Console.WriteLine("Roooooaaaaar");
        }
    }
}
