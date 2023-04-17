using StaticExtension.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExtension.Models
{
    internal class Dog
    {
        public string Name { get; set; }
        public Dog(string name)
        {
            Name = name.Capitalize();
        }
    }
}
