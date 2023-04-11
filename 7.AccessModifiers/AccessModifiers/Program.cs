using AccessModifiers.Models;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Person person=new Person();
          Employee employee=new Employee();
            
            Console.WriteLine(person.Age);
           
        }
    }
}