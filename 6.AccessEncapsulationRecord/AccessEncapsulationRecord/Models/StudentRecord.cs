using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessEncapsulationRecord.Models
{
    //internal record StudentRecord:PersonRecord
    //{
    //    public StudentRecord(string name,byte age):base(name,age)
    //    {

    //    }
    //}
    internal record StudentRecord(string Name, byte Age):PersonRecord(Name,Age);
}
