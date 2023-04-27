using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectoryJson.Models
{
    internal class Group
    {

        public static int Count=0;
        public int Id { get; set; }
        public string Name { get; set; }
        public Group(string name)
        {
            Count++;
            Id = Count;
            Name = name;
        }
    }
}
