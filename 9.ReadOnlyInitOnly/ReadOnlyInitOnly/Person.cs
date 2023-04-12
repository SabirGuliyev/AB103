using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyInitOnly
{
    internal class Person
    {
        public const string University="AZTU";

        public readonly string Id;//readonly

        public string Username { get;} //get only auto preperty

        public string Group { get; init;} //init only
        public Person()
        {
            
        }
    }
}
