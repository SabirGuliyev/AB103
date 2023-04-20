using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionException.Models
{
    internal abstract class Animal
    {
        public byte AvgLifetime { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine("Yem yeyir");
        }

        public abstract void MakeSound();
    }
}
