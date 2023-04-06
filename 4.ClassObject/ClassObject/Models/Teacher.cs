using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObject.Models
{
    internal class Teacher:Student
    {
        public decimal Salary;

        public Teacher()
        {
            Console.WriteLine("Teacher ctoru ishe dushdu");
        }
    }
}
