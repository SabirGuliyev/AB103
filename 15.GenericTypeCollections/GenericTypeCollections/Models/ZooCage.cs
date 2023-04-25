using GenericTypeCollections.Models.Animals;
using GenericTypeCollections.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeCollections.Models
{
    internal class ZooCage<T,U> where T : Animal
                                where U : Food
    {

        public T Animal { get; set; }

        public U Food { get; set; }

        public ZooCage(T animal)
        {
            Animal = animal;
        }
       

    }
}
