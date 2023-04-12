using AbstractVirtualPolymorphism.Models;

namespace AbstractVirtualPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dog dog = new Dog
            {
                AvgLifeTime = 8,
                _name = "Bobik",
                Breed = "German Shepard"
            };

            Cow cow = new Cow
            {
                AvgLifeTime = 3,
                _name = "Alagoz",
            };


            Animal animal = new Dog();


            Animal[] zoo = { dog, cow };
            foreach (Animal a in zoo)
            {
                Console.WriteLine(a._name);
            }







            //dog.MakeSound();
            //cow.MakeSound();
            //dog.Eat();
            //cow.Eat();

















            //Person person = new Person { Name = "Sabir" };
            //Student student = new Student { Name = "Saleh", Group = "AB103" };

            //Console.WriteLine(person);
            //Console.WriteLine(student);
            //person.GetInfo();
            //student.GetInfo();


        }
    }
}