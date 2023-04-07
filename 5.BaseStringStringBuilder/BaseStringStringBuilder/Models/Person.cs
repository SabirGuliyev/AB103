using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseStringStringBuilder.Models
{
    internal class Person
    {
        public string Name;

        public string Surname;

        public byte Age;
        public Person()
        {

        }
        public Person(string name)
        {
            Name = name;
        }
        public void GetInfo()
        {
            Console.WriteLine(Name+" "+Surname+" "+Age);

        }
    }
}
