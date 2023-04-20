using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionException.Models
{
    internal class Eagle:Animal
    {

        public byte FlySpeed { get; set; }

        public void Fly()
        {
            Console.WriteLine("Flied");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Sound like qartal");
        }
    }
}
