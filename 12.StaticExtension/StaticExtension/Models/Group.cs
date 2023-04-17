using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExtension.Models
{
    internal class Group
    {

        public static Group[] Groups=new Group[0];


        public string Name { get; set; }
        public static void Add(Group group)
        {
            Array.Resize(ref Groups,Groups.Length-1);
            Groups[Groups.Length-1] = group;
        }


    }
}
