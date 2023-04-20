using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionException.Exceptions
{
    internal class WrongValueException:Exception
    {

        public WrongValueException(string message):base(message)
        {

        }
    }
}
