using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeCollections.Models.Animals
{
    internal abstract class Animal
    {
        public string Name { get; set; }
        public byte AvgLifetime { get; set; }

        public void MakeSound()
        {
            Console.WriteLine("Animal ses cixardi");
        }
    }
}
