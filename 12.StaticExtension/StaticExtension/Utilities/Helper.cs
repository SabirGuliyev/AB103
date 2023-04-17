using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExtension.Utilities
{
    internal static class Helper
    {

        public static string WifiPass="Salam123";
        public static int MyProperty { get; set; }

        public static string Capitalize(this string name)
        {
            Console.WriteLine();
            return Char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        
    }
}
