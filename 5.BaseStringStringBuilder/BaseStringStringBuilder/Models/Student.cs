using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseStringStringBuilder.Models
{
    internal class Student:Person
    {

        public string GroupName;

        public Student()
        {
            Console.WriteLine("Student created");
        }
        public Student(string name):base(name)
        {

        }
    }
}
