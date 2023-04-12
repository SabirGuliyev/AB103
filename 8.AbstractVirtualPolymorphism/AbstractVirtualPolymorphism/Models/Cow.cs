using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVirtualPolymorphism.Models
{
    internal class Cow:Animal
    {
        public override void MakeSound()
        {
            
            Console.WriteLine("Mooooo");
        }

        public void ProduceMilk()
        {
            Console.WriteLine("Milk produced");
        }
    }
}
