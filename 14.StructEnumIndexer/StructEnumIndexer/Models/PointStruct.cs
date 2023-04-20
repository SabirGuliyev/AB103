using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructEnumIndexer.Models
{
    internal struct PointStruct
    {
       int X { get; set; }
       int Y { get; set; }

        public PointStruct(int x, int y):this()
        {
            X = x;
            Y = y;
        }
        public PointStruct()
        {
            X = 0;
            Y = 0;
        }
        public void GetCordinates()
        {
            Console.WriteLine(X+" "+Y);
        }

            }
}
