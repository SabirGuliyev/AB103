using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObject.Models
{
    internal class Student:Person
    {
        public string Group;

        public Student(string name) : base(name)
        {
            
        }
        public Student(string name,string group):this(name)
        {
            Group = group;
            Console.WriteLine("Student ctor ishe dushdu");
        }
    }
}
