using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeCollections
{
    internal class Product<T>
    {
        public decimal Price { get; set; }

        public T Quality { get; set; }

      


        public Product(T quality)
        {
            Quality = quality;
        }


        public T Print(T item)
        {
            
            Console.WriteLine(item);

            return item;
        }

      
    }
}
