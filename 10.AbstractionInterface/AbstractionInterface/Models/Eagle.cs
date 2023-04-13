using AbstractionInterface.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionInterface.Models
{
    internal class Eagle :Bird,IFly
    {
        public byte _age;
        public byte Claws { get; set; }
        public byte Age { get; set; }
        public int FlySpeed { get; set; }

        public void Fly()
        {
            Console.WriteLine("Eagle flied");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Sound like Eagle");
        }
    }
}
