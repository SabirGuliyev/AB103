using AbstractionInterface.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionInterface.Models
{
    internal class Penguin : Bird,ISwim
    {
        public int SwimSpeed { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine("Sounds like pengiun");
        }

        public void Swim()
        {
            Console.WriteLine("Penguin swam");
        }
    }
}
