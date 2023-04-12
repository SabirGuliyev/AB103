using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVirtualPolymorphism.Models
{
    internal abstract class Animal
    {
        public string _name;
        public byte AvgLifeTime { get; set; }

        public Animal()
        {
            Console.WriteLine("Animal created");
        }
        public virtual void Eat()
        {
            Console.WriteLine("Yem ile qidalandi");
        }
        public abstract void MakeSound();
       
    }
}
