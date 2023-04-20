using ReflectionException.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionException
{
    internal class Student
    {
        byte _age;

        string _name;

        public byte Age { get { return _age; } 
            set 
            {
                if (value>0&&value<150)
                {
                    _age = value;
                }
                else
                {
                    throw new WrongValueException($"{value} age is overflow");
                }
                
            } 
        }
        public string Name { get { return _name; } 
            set 
            { 
                value = value.Trim();
                if (value.Length>=3 && value.Length<25)
                {
                    _name = value;
                }
                else
                {
                    throw new WrongValueException($"{value} name is not coorrect");
                }

            }
        }

        public Student(byte age, string name)
        {
            Age = age;
            Name = name;
        }
    }
}
