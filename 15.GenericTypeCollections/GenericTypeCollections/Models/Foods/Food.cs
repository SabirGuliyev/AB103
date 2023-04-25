using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeCollections.Models.Foods
{
    internal abstract class Food
    {
        public DateTime ProDate { get; set; }

        public string Name { get; set; }
    }
}
