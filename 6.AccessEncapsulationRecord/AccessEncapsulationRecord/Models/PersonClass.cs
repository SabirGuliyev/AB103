using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessEncapsulationRecord.Models
{
    public class PersonClass
    {
        private string _name;
        public byte _age;

        public string Name 
        {
            get 
            {

                return _name;
            }
            set
            {
                value=value.Trim();
                if (value.Length>=3&&value.Length<=25)
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Yanlish deyer");
                }
            }
        }

        public byte Age { 
            get
            {
                return _age;
            }
            set
            {
                if (value>=0&&value<=200)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Yash menfi ve ya 2 esrden boyuk ola bilmez");
                }
                
            }
        }

        public PersonClass(string name,byte age)
        {
            Name=name;
            Age = age;
        }


        public void GetInfo()
        {
            Console.WriteLine($"Name:{Name}");
        }

       
        public string Capitalize(string name)
        {
            return name.ToUpper();
        }
        #region Encapsul in Java
        //public string GetName()
        //{

        //    return Name;
        //}
        //public void SetName(string name)
        //{
        //    name=name.Trim();

        //    if (name.Length>=3)
        //    {
        //        Name = Capitalize(name);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Deyer yanlishdir");
        //    }

        //} 
        #endregion
    }






  
}
