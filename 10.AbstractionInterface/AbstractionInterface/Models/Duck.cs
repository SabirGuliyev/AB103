using AbstractionInterface.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionInterface.Models
{
    internal class Duck : Bird,IFlySwim
    {
        public int FlySpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SwimSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public override void MakeSound()
        {
            Console.WriteLine("Sound like duck");
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
}
