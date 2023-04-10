using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessEncapsulationRecord.Models
{
    //internal record PersonRecord(string Name,byte Age);

    internal record PersonRecord
    {
        private string _name;
        private byte _age;

        public string Name { get { return _name; } init { _name = value; } }
        public byte Age { get { return _age; } init { _age = value; } }

        
        public PersonRecord(string name, byte age)
        {
            Name = name;
            Age = age;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Name:{Name}");
        }

    }
}
