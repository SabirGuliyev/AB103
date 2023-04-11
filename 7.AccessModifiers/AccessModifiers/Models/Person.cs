using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Models
{
    public class Person//Default Internal
    {
        public string Name;

        private protected string Id;

        protected internal int Age;
        public Person()
        {
            Person person = new Person();
        }

        
    }
}
