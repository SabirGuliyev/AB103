using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionInterface.Models
{
    internal abstract class Animal
    {
        public byte AvgLifetime { get; set; }
        public string Name { get; set; }

        public abstract void MakeSound();
        public virtual void Eat()
        {
            Console.WriteLine("Yem ile qidalandi");
        }
    }
}
