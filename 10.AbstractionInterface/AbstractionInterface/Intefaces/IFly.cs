using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionInterface.Intefaces
{
    internal interface IFly
    {
        public int FlySpeed { get; set; }
        void Fly(); //Default public
      
    }
}
