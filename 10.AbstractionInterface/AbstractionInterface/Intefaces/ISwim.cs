using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionInterface.Intefaces
{
    internal interface ISwim
    {
        int SwimSpeed { get; set; }

        void Swim();
    }
}
