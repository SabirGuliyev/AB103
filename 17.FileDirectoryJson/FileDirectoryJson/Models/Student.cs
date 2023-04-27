using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectoryJson.Models
{
    internal class Student
    {
        public static int Count=0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Group Group { get; set; }
        public Student(string name, string surname,Group group)
        {
            Count++;
            Id = Count;

            Name = name;
            Surname = surname;
            Group = group;
        }
    }
}
