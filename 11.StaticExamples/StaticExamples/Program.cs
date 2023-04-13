namespace StaticExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine(Person.Count);

            Person person = new Person("Sabir", "Guliyev");
            Person person2 = new Person("Arif", "Abdulla");
            Person person3 = new Person("Nahidd", "Memmedov");
            Person person4 = new Person("Nahidd", "Memmedov");


            //Person[] people = {person,person2,person3,person4};


            //foreach (Person item in people)
            //{
            //    item.GetInfo();
            //}


            //Person.Count = 50000;
            //Console.WriteLine(Person.Count);


        }
    }
}